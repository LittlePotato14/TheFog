using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Скрипт для диалоговых окон с правилами игры.
/// </summary>
public class RulesScript : MonoBehaviour
{
    public GameObject box;
    public Text text;

    // Нужен для переключения текста в окне до переключения между окнами.
    private int iter = 0;

    // Все предложения, которые будут показаны в окне.
    public string[] sentences;

    // Следующее окно.
    public GameObject next;

    // Является ли окно первым.
    public bool isFirst = false;

    private Globals globals;

    /// <summary>
    /// Вызывается один раз при запуске.
    /// </summary>
    void Start()
    {
        globals = Camera.main.GetComponent<Globals>();

        if (!globals.EndRules && isFirst)
            text.text = sentences[0];
        else
            box.SetActive(false);
    }

    /// <summary>
    /// Показывает окошко с правилами.
    /// </summary>
    public void Show()
    {
        iter = 0;
        box.SetActive(true);
        text.text = sentences[0];
    }

    /// <summary>
    /// Вызывается при нажатии на кнопку в окне.
    /// </summary>
    public void OnButton()
    {
        // Если текст закончился.
        if (iter >= sentences.Length - 1)
        {
            // Открываем следующее окно.
            if (next != null)
                next.GetComponent<RulesScript>().Show();

            // Конец правил.
            else
                globals.EndRules = true;
            box.SetActive(false);
            return;
        }

        // Обновление текста.
        text.text = sentences[++iter];
    }
}
