using System.Collections;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool isAppQuit = false;
    private static T _instance;

    protected static bool destroyOnLoad = true;

    public static T Instance
    {
        get 
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();

                if (_instance == null)
                {
                    if (isAppQuit) return null;

                    GameObject singleton = new GameObject("_" + typeof(T).Name);
                    _instance = singleton.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        isAppQuit = false;
        if (_instance == null)
        {
            _instance = this as T;
            if (destroyOnLoad == true)
                DontDestroyOnLoad(gameObject);
        }
        else 
        {
            if(destroyOnLoad)
                Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        isAppQuit = true;
    }
}

public class Singleton<T> where T : class, new()
{
    private static T mInstance = null;
    public static T instance
    {
        get
        {
            if (mInstance == null)
                mInstance = new T();

            return mInstance;
        }
    }
}
