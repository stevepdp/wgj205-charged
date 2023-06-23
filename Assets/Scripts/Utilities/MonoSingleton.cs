using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<T>();
            return instance;
        }
    }

    public virtual void Awake()
    {
        EnforceSingleton();
    }

    void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    void EnforceSingleton()
    {
        if (instance != null)
            Destroy(gameObject);

        instance = this as T;
    }
}