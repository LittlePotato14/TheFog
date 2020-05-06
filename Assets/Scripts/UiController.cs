using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Контроллер для канваса поверх уровня.
/// </summary>
public class UiController : MonoBehaviour
{
    // Счётчик углов.
    public AngleBar angleBar;

    // Объект для клонирования.
    public Object arrow;

    private Globals globals;
    
    /// <summary>
    /// Вызывается один раз при запуске.
    /// </summary>
    void Start()
    {
        globals = Camera.main.GetComponent<Globals>();
    }
    
    /// <summary>
    /// Нажатие на кнопку pause.
    /// </summary>
    public void StartOrPause()
    {
        var hero = GameObject.FindGameObjectsWithTag("hero")[0];

        // pause
        if (globals.Playing)
        {
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            hero.transform.rotation = Quaternion.identity;
            hero.transform.Rotate(0f, 0f, globals.GetDegreeAngle(globals.startDirection));
            hero.transform.position = globals.startPosition;
            angleBar.SetAngle(0);
        }
        // start
        else
        {
            hero.GetComponent<Rigidbody2D>().AddForce(globals.startDirection * globals.speed, ForceMode2D.Impulse);
        }

        globals.Playing = !globals.Playing;
    }

    /// <summary>
    /// Добавление клона объекта поворота.
    /// </summary>
    public void AddArrow()
    {
        Instantiate(arrow, new Vector3(0, 0, 0), Quaternion.identity);
    }

    /// <summary>
    /// Выход с уровня в стартовое меню.
    /// </summary>
    public void ExitLevel()
    {
        SceneManager.LoadScene("Start");
    }
}
