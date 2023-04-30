using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object pool that can return desired components' references without using GetComponent
/// </summary>

public class ObjectPooling : SingletonBlankMonoBehavior<ObjectPooling> {    
    private ComponentPool m_componentPool = new ComponentPool();
    public void PreloadPool<T>(T _originalReference, int _count = 1) where T : Component => m_componentPool.AddToPool(_originalReference, _count);
    public T Spawn<T>(T _originalReference) where T : Component { return m_componentPool.GetAvailableObject(_originalReference); }
    public void Recycle<T>(T _cloneReference) where T : Component => m_componentPool.ReturnCloneToPool(_cloneReference);
}

public class ComponentPool {
    //the queue of pooled components by their type and asset reference
    private Dictionary<GameObject, Queue<Component>> dict_m_pooledComponentByType = new Dictionary<GameObject, Queue<Component>>();

    //dictionaries of instantied objects and their original object
    private Dictionary<GameObject, GameObject> dict_m_originalByClone = new Dictionary<GameObject, GameObject>();

    /// <summary>
    /// Add new objects to the pool.
    /// </summary>
    /// <param name="originalReference">Referenced object</param>
    /// <param name="count">Number of objects</param>
    /// <typeparam name="T">Type reference of the object</typeparam>
    /// <returns></returns>
    public Queue<Component> AddToPool<T>(T originalReference, int count = 1) where T : Component {
        Queue<Component> components;

        if (dict_m_pooledComponentByType.TryGetValue(originalReference.gameObject, out components) == false) {
            dict_m_pooledComponentByType.Add(originalReference.gameObject, components = new Queue<Component>());
        }

        if (count < 0) {
            Debug.LogError("Count cannot be negative");
            return null;
        }

        //Create the type of component x times
        for (int i = 0; i < count; i++) {
            //Instantiate new component and UPDATE the List of components
            Component clone = Object.Instantiate(originalReference);
            dict_m_originalByClone.Add(clone.gameObject, originalReference.gameObject);
            //De-activate each one until when needed
            clone.gameObject.SetActive(false);
            components.Enqueue(clone);
        }

        return components;
    }


    //Get available component in the ComponentPool
    public T GetAvailableObject<T>(T originalReference) where T : Component {
        //Get all component with the requested type from  the Dictionary
        if (dict_m_pooledComponentByType.TryGetValue(originalReference.gameObject, out Queue<Component> components)) {
            if (components.Count > 0) {
                var component = components.Dequeue();
                component.gameObject.SetActive(true);
                return (T)component;
            }
        }

        //No available object in the pool. Expand list
        //Create new component, activate the GameObject and return it
        Component clone = AddToPool(originalReference).Dequeue();
        clone.gameObject.SetActive(true);
        return (T)clone;
    }

    public void ReturnCloneToPool<T>(T cloneReference) where T : Component {
        Queue<Component> components;

        GameObject clone = cloneReference.gameObject;
        clone.transform.position = Vector3.zero;
        clone.transform.rotation = Quaternion.identity;
        clone.SetActive(false);

        GameObject original = GetOriginal(clone);

        if (dict_m_pooledComponentByType.TryGetValue(original, out components) == false) {
            dict_m_pooledComponentByType.Add(original, components = new Queue<Component>());
        }

        components.Enqueue(cloneReference);
    }

    private GameObject GetOriginal(GameObject clone) {
        if (dict_m_originalByClone.TryGetValue(clone, out var original)) return original;
        return SetOriginal(clone, clone);
    }

    private GameObject SetOriginal(GameObject clone, GameObject original) {
        if (dict_m_originalByClone.ContainsKey(clone) == false) dict_m_originalByClone.Add(clone, original);
        return original;
    }
}

public static class ObjectPoolExtension {
    public static void CreatePool(this Component component, int count = 1) => ObjectPooling.Instance.PreloadPool(component, count);
    public static void ReturnToPool(this Component component) => ObjectPooling.Instance.Recycle(component);
    public static T SpawnFromPool<T>(this T component) where T : Component { return ObjectPooling.Instance.Spawn(component); }
}
