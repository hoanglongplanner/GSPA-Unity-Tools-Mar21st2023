using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPersistMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour
{
    private void Awake() {
        
    }

    public virtual void SingletonAwake() {

    }
}
