using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AngleBar angleBar;
    public float moveSpeed = 10f;
    public float rotateSpeed = 150f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "arrow" && Globals.Playing)
        {
            float angle = other.gameObject.transform.rotation.eulerAngles.z;
            var cos = Mathf.Cos(angle * Mathf.PI / 180);
            var sin = Mathf.Sin(angle * Mathf.PI / 180);
            var first = Globals.GetDegreeAngle(gameObject.GetComponent<Rigidbody2D>().velocity);
            var second = Globals.GetDegreeAngle(new Vector2(cos, sin));
            var angleDif = Mathf.Abs(first - second);
            angleDif = angleDif > 180 ? 360 - angleDif : angleDif;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(cos, sin) * Globals.speed;

            angleBar.IncreaseAngle(angleDif);
            return;
        }
    }

    void Start()
    {
        transform.Rotate(0f, 0f, Globals.GetDegreeAngle(Globals.startDirection));
    }

    public void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.magnitude > 0)
        {
            var angle = Globals.GetDegreeAngle(GetComponent<Rigidbody2D>().velocity);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            AnimatorHedge.anim.SetBool("running", true);
        }
        else
        {
            AnimatorHedge.anim.SetBool("running", false);
        }
    }
}