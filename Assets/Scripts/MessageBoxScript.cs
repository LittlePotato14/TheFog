using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Скрипт для окна сообщения/ошибки.
/// </summary>
public class MessageBoxScript : MonoBehaviour
{
    public GameObject canvas;
    public Text textField;
    public Button playButton;
    private Globals globals;
    bool endLevel;

    /// <summary>
    /// Вызывается один раз при запуске.
    /// </summary>
    void Start()
    {
        globals = Camera.main.GetComponent<Globals>();
        canvas.SetActive(false);
    }

    /// <summary>
    /// Показать окно.
    /// </summary>
    /// <param name="message"> Текст сообщения. </param>
    /// <param name="endLev"> Является ли окно уведомлением об окончании уровня. </param>
    public void Show(string message, bool endLev = false)
    {
        endLevel = endLev;
        textField.text = message;
        canvas.SetActive(true);
        playButton.interactable = false;
    }

    /// <summary>
    /// Вызывается при нажатии на кнопку в окне.
    /// </summary>
    public void NotPlaying()
    {
        // Переход к следующему уровню.
        if (endLevel)
        {
            var obj = Progress.GetInstance();
            obj.CurrentLevel += 1;
            if(obj.CurrentLevel <= obj.LevelAmount)
                SceneManager.LoadScene("Map" + obj.CurrentLevel);
            else
                SceneManager.LoadScene("GameOver");
            return;
        }

        globals.Playing = false;
        playButton.interactable = true;
        canvas.SetActive(false);
    }
}
