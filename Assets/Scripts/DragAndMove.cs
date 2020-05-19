using UnityEngine;

/// <summary>
/// Захват и передвижение объектов.
/// </summary>
public class DragAndMove : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool selected = false;
    private bool moved = false;
    public GameObject sprite;
    public GameObject self;
    public float rotateSpeed = 150f;
    public bool isBeingHeld = false;
    private Globals globals;

    /// <summary>
    /// Вызывается один раз при запуске.
    /// </summary>
    void Start()
    {
        globals = Camera.main.GetComponent<Globals>();
    }

    /// <summary>
    /// Вызывается раз за кадр.
    /// </summary>
    void Update()
    {
        // Если включена анимация уровня.
        if (globals.Playing)
        {
            selected = false;
            moved = false;
            sprite.GetComponent<SpriteRenderer>().color = globals.nonSelected;
            isBeingHeld = false;
            return;
        }

        // Передвигается.
        if (selected && isBeingHeld && !globals.Playing)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            var newPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);

            // Если было измеение позиции.
            if (gameObject.transform.localPosition != newPosition)
            {
                gameObject.transform.localPosition = newPosition;
                moved = true;
            }
        }

        // Поворот и удаление.
        if (selected && !globals.Playing)
        {
            if (Input.GetKeyUp(KeyCode.Delete))
            {
                DestroyImmediate(self);
                return;
            }
            float rotateVector = Input.GetAxis("Horizontal");
            gameObject.transform.Rotate(0, 0, -rotateVector * rotateSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// При нажатии на лкм.
    /// </summary>
    public void OnMouseDown()
    {
        if (selected && !globals.Playing && Input.GetMouseButtonDown(0))
        {
            isBeingHeld = true;

            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;
        }
    }

    /// <summary>
    /// При отжатии.
    /// </summary>
    public void OnMouseUp()
    {
        // Если не был выбран объект, то теперь он выбран.
        if (!selected)
        {
            selected = true;
            sprite.GetComponent<SpriteRenderer>().color = globals.selected;
            return;
        }

        // Если объект не был передвинут, то теперь он не выбран.
        if (!moved)
        {
            selected = false;
            sprite.GetComponent<SpriteRenderer>().color = globals.nonSelected;
        }

        moved = false;
        isBeingHeld = false;
    }
}
