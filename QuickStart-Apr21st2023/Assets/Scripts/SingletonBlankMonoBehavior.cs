using UnityEngine;

public class SingletonBlankMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour {
    private static T instance;

    public static T Instance {
        get => instance ? instance : instance = FindObjectOfType(typeof(T)) as T;
        set => instance = value;
    }

    private void Awake() {
        if (instance != null) {            
            if (this == null) 
                return;
        }

        instance = this as T;

        SingletonAwake();
    }

    protected virtual void OnDestroy() => instance = null;

    public virtual void SingletonAwake() { }
}
