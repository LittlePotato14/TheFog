using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Скрипт для повторной игры после окончания.
/// </summary>
public class PlayAgain : MonoBehaviour
{
    /// <summary>
    /// Нажатие на кнопку повтора.
    /// Обновляем json.
    /// </summary>
    public void OnButton()
    {
        var inst = Progress.GetInstance();
        inst.CurrentLevel = 1;
        inst.EndRule = false;
        Progress.Serialize();
        SceneManager.LoadScene("Start");
    }
}
