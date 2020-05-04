using UnityEngine;

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

    public void Update()
    {
        if (Globals.Playing)
        {
            selected = false;
            moved = false;
            sprite.GetComponent<SpriteRenderer>().color = Globals.nonSelected;
            isBeingHeld = false;
            return;
        }
        if (selected && isBeingHeld && !Globals.Playing)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            var newPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
            if (gameObject.transform.localPosition != newPosition)
            {
                gameObject.transform.localPosition = newPosition;
                moved = true;
            }
        }

        //rotation and delete
        if (selected && !Globals.Playing)
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

    public void OnMouseDown()
    {
        if (selected && !Globals.Playing && Input.GetMouseButtonDown(0))
        {
            isBeingHeld = true;

            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;
        }
    }

    public void OnMouseUp()
    {
        if (!selected)
        {
            selected = true;
            sprite.GetComponent<SpriteRenderer>().color = Globals.selected;
            return;
        }
        if (!moved)
        {
            selected = false;
            sprite.GetComponent<SpriteRenderer>().color = Globals.nonSelected;
        }
        moved = false;
        isBeingHeld = false;
    }
}
