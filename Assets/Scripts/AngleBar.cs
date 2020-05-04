using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngleBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text counter;
    public GameObject dialogCanvas;

    public float GetDegreeAngle(float x, float y)
    {
        var angle = Mathf.Atan2(y, x);
        return angle / Mathf.PI * 180.0f;
    }

    public void IncreaseAngle(float ang)
    {
        if (slider.value + ang < slider.maxValue)
        {
            slider.value += ang;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            counter.text = $"{Mathf.Round(slider.value)}/{slider.maxValue}";
        }
        else
        {
            var hero = GameObject.FindGameObjectsWithTag("hero")[0];
            hero.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            hero.transform.rotation = Quaternion.identity;
            hero.transform.Rotate(0f, 0f, GetDegreeAngle(Globals.startDirection.x, Globals.startDirection.y));
            hero.transform.position = Globals.startPosition;
            SetAngle(0);
            dialogCanvas.GetComponent<MessageBoxScript>().Show("Допустимый угол поворота был превышен.");
        }
    }

    public void SetAngle(float ang)
    {
        slider.value = ang;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        counter.text = $"{Mathf.Round(slider.value)}/{slider.maxValue}";
    }

    void Start()
    {
        slider.maxValue = Globals.maxAngle;
        slider.value = 0;
        fill.color = gradient.Evaluate(1f);
        counter.text = $"{Mathf.Round(slider.value)}/{slider.maxValue}";
    }
}
