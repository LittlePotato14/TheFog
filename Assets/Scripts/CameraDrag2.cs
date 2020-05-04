using UnityEngine;

public class CameraDrag2 : MonoBehaviour
{
    public float dragSpeed = 10;
    private Vector3 dragOrigin;
    public Vector2 panLimit;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(1)) return;

        Vector3 move = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition) * dragSpeed;
        transform.Translate(move, Space.World);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
        pos.z = transform.position.z;
        transform.position = pos;

        dragOrigin = Input.mousePosition;
    }
}
