using UnityEngine;

/// <summary>
/// Base class for singleton instances in Unity.
/// <remarks>
/// <para>Unity 单例基类</para>
/// </remarks>
/// </summary>
/// <typeparam name="T">The type of the singleton instance.</typeparam>
public abstract class SingleInstance<T> : MonoBehaviour where T : SingleInstance<T>
{
    protected abstract string GameObjectName { get; }

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T candidateSingleton = FindOrCreateSingleton();
                candidateSingleton.InstanceAwake();
                _instance = candidateSingleton;
            }
            return _instance;
        }
    }

    /// <summary>
    /// Finds or creates the singleton instance.
    /// <remarks>
    /// <para>查找或创建单例实例</para>
    /// </remarks>
    /// </summary>
    /// <returns></returns>
    private static T FindOrCreateSingleton()
    {
        // Find existing instances
        T[] candidateSingletonArray = FindObjectsOfType<T>();

        if (candidateSingletonArray.Length > 1)
        {
            for (int i = 1; i < candidateSingletonArray.Length; i++)
            {
                candidateSingletonArray[i].gameObject.SetActive(false);
            }
            Debug.LogError("Multiple candidate singletons found. The extra singletons have been disabled. Please ensure that only one singleton instance exists.");
        }
        if (candidateSingletonArray.Length > 0)
        {
            return candidateSingletonArray[0];
        }

        // Create a new instance
        T result = new GameObject().AddComponent<T>();
        result.gameObject.name = result.GameObjectName;
        return result;
    }

    /// <summary>
    /// Initializes the singleton instance.
    /// <remarks>
    /// <para>初始化单例实例</para>
    /// </remarks>
    /// </summary>
    public static void Initialize()
    {
        Initialize(FindOrCreateSingleton());
    }

    /// <summary>
    /// Initializes the singleton instance with the provided candidate.
    /// <remarks>
    /// <para>使用提供的候选实例初始化单例实例</para>
    /// </remarks>
    /// </summary>
    /// <param name="candidateSingleton">The candidate singleton instance.</param>
    public static void Initialize(T candidateSingleton)
    {
        candidateSingleton.InstanceAwake();
        // Debug.Log("Single Instance GameObject Awaked: " + candidateSingleton.gameObject.name + ".");
        _instance = candidateSingleton;
    }

    /// <summary>
    /// Called when the singleton instance is awakened.
    /// <remarks>
    /// <para>单例实例被唤醒时调用</para>
    /// </remarks>
    /// </summary>
    protected virtual void InstanceAwake() { }
}
