using UnityEngine;

/// <summary>
/// Для сохранения аудио между сценами.
/// </summary>
public class DoNotDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
