using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public AngleBar angleBar;
    public Object arrow;

    public void StartOrPause()
    {
        var hero = GameObject.FindGameObjectsWithTag("hero")[0];

        // pause
        if (Globals.Playing)
        {
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            hero.transform.rotation = Quaternion.identity;
            hero.transform.Rotate(0f, 0f, Globals.GetDegreeAngle(Globals.startDirection));
            hero.transform.position = Globals.startPosition;
            angleBar.SetAngle(0);
        }
        // start
        else
        {
            hero.GetComponent<Rigidbody2D>().AddForce(Globals.startDirection * Globals.speed, ForceMode2D.Impulse);
        }

        Globals.Playing = !Globals.Playing;
    }

    public void AddArrow()
    {
        Instantiate(arrow, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Start");
    }
}
