using UnityEngine;

/// <summary>
/// Скрипт передвижения камеры.
/// </summary>
public class CameraDrag2 : MonoBehaviour
{
    public float dragSpeed = 10;
    private Vector3 dragOrigin;
    public Vector2 panLimit;

    /// <summary>
    /// Вызывается раз в кадр.
    /// </summary>
    void Update()
    {
        // Была нажата пкм.
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        // Не зажата пкм.
        if (!Input.GetMouseButton(1)) return;

        // Двигаем камеру.
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
