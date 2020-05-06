using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Настройки уровня.
/// </summary>
public class Globals : MonoBehaviour
{
    /// <summary>
    /// Вызывается один раз при запуске.
    /// </summary>
    void Start()
    {
        EndRules = Progress.GetInstance().EndRule;
    }

    /// <summary>
    /// Возвращает угол поворота по переданному вектору.
    /// </summary>
    /// <param name="vec"> Вектор. </param>
    /// <returns> Угол в градусах. </returns>
    public float GetDegreeAngle(Vector2 vec)
    {
        var angle = Mathf.Atan2(vec.y, vec.x) / Mathf.PI * 180.0f;
        return angle > 0 ? angle : 360 + angle;
    }
    
    /// <summary>
    /// Пройдены ли правила.
    /// </summary>
    bool endRules = false;
    public bool EndRules {
        get => endRules;
        set {
            endRules = value;
            Progress.GetInstance().EndRule = endRules;
            Progress.Serialize();
        }
    }

    public float speed = 1.5f;
    public Vector2 startDirection = new Vector2(0.5f, 1);
    public float maxAngle = 360;
    public Vector3 startPosition = new Vector3(-3, -2, 0);
    // Цвет выбранного объекта.
    public Color selected = new Color(0, 255, 255);
    // Цвет невыбранного объекта.
    public Color nonSelected = new Color(0, 0, 0);

    // Идёт ли анимация уровня.
    private bool playing = false;
    public bool Playing {
        get => playing;
        set {
            playing = value;
            GameObject.Find("addArrow").GetComponent<Button>().interactable = !playing;
        }
    }
}
