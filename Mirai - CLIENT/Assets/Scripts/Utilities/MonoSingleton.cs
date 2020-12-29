using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private bool _initialized = false;

    private static T _instance = null;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType(typeof(T)) as T;
            }

            if( _instance. _initialized == false)
            {
                _instance.Init();
            }

            return _instance;
        }
    }

    protected virtual void Init()
    {
        _initialized = true;
    }

    protected void OnApplicationQuit()
    {
        _instance = null;
    }
}
