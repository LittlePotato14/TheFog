using UnityEngine;

/// <summary>
/// Скрипт для контроллера игрока.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public AngleBar angleBar;
    public float moveSpeed = 10f;
    public float rotateSpeed = 150f;
    private Globals globals;
    public GameObject dialogCanvas;

    /// <summary>
    /// Коллизия с триггерным предметом.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Коллизия с предметом поворота.
        if (other.gameObject.tag == "arrow" && globals.Playing)
        {
            float angle = other.gameObject.transform.rotation.eulerAngles.z;
            var cos = Mathf.Cos(angle * Mathf.PI / 180);
            var sin = Mathf.Sin(angle * Mathf.PI / 180);
            var first = globals.GetDegreeAngle(gameObject.GetComponent<Rigidbody2D>().velocity);
            var second = globals.GetDegreeAngle(new Vector2(cos, sin));
            var angleDif = Mathf.Abs(first - second);
            angleDif = angleDif > 180 ? 360 - angleDif : angleDif;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(cos, sin) * globals.speed;

            // Увеличиваем счётчик углов.
            angleBar.IncreaseAngle(angleDif);
        }

        // Коллизия с точкой конца уровня.
        else if (other.gameObject.tag == "endPoint" && globals.Playing)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            dialogCanvas.GetComponent<MessageBoxScript>().Show("Уровень пройден.", true);
        }

        // Коллизия с опасной точкой.
        else if(other.gameObject.tag == "danger" && globals.Playing)
        {
            // Устанаваливаем начальные настройки.
            var hero = GameObject.FindGameObjectsWithTag("hero")[0];
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            hero.transform.rotation = Quaternion.identity;
            hero.transform.Rotate(0f, 0f, globals.GetDegreeAngle(globals.startDirection));
            hero.transform.position = globals.startPosition;
            angleBar.SetAngle(0);

            // Показываем уведомление.
            dialogCanvas.GetComponent<MessageBoxScript>().Show("Вы попали в опасную зону.");
        }
    }

    /// <summary>
    /// Вызывается один раз при старте.
    /// </summary>
    void Start()
    {
        globals = Camera.main.GetComponent<Globals>();
        transform.Rotate(0f, 0f, globals.GetDegreeAngle(globals.startDirection));
    }

    /// <summary>
    /// Вызывается за фиксированное время.
    /// </summary>
    public void FixedUpdate()
    {
        // Если герой движется.
        if (GetComponent<Rigidbody2D>().velocity.magnitude > 0)
        {
            var angle = globals.GetDegreeAngle(GetComponent<Rigidbody2D>().velocity);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            AnimatorHedge.anim.SetBool("running", true);
        }

        // Если герой стоит.
        else
        {
            AnimatorHedge.anim.SetBool("running", false);
        }
    }
}