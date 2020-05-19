using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Скрипт счётчика угла.
/// </summary>
public class AngleBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text counter;
    public GameObject dialogCanvas;
    private Globals globals;

    /// <summary>
    /// Увеличивает счётчик углов на переданное значение.
    /// </summary>
    /// <param name="angle"> Значение увеличения. </param>
    public void IncreaseAngle(float angle)
    {
        // Игра продолжается.
        if (slider.value + angle < slider.maxValue)
        {
            slider.value += angle ;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            counter.text = $"{Mathf.Round(slider.value)}/{slider.maxValue}";
        }

        // Уровень не пройден. 
        else
        {
            // Устанаваливаем начальные настройки.
            var hero = GameObject.FindGameObjectsWithTag("hero")[0];
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            hero.transform.rotation = Quaternion.identity;
            hero.transform.Rotate(0f, 0f, globals.GetDegreeAngle(globals.startDirection));
            hero.transform.position = globals.startPosition;
            SetAngle(0);

            // Показываем уведомление.
            dialogCanvas.GetComponent<MessageBoxScript>().Show("Допустимый угол поворота был превышен.");
        }
    }

    /// <summary>
    /// Установить счётчик угла на переданное значение.
    /// </summary>
    /// <param name="angle"> Новое значение счётчика. </param>
    public void SetAngle(float angle)
    {
        slider.value = angle;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        counter.text = $"{Mathf.Round(slider.value)}/{slider.maxValue}";
    }

    /// <summary>
    /// Вызывается один раз при запуске.
    /// </summary>
    void Start()
    {
        globals = Camera.main.GetComponent<Globals>();
        slider.maxValue = globals.maxAngle;
        slider.value = 0;
        fill.color = gradient.Evaluate(1f);
        counter.text = $"{Mathf.Round(slider.value)}/{slider.maxValue}";
    }
}
