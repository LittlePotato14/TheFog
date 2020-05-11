using UnityEngine;

/// <summary>
/// Для сохранения аудио между сценами.
/// </summary>
public class DoNotDestroy : MonoBehaviour
{
    static GameObject instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
    }
}
