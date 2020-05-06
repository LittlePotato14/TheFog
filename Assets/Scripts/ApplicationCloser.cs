using UnityEngine;

/// <summary>
/// Скрипт закрытия приложения.
/// </summary>
public class ApplicationCloser : MonoBehaviour
{
    /// <summary>
    /// Закрыть.
    /// </summary>
    public void CloseApplication()
    {
        Application.Quit();
    }
}
