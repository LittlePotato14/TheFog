using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Globals
{
    public static float GetDegreeAngle(Vector2 vec)
    {
        var angle = Mathf.Atan2(vec.y, vec.x) / Mathf.PI * 180.0f;
        return angle > 0 ? angle : 360 + angle;
    }

    public static float speed = 1.5f;
    public static Vector2 startDirection = new Vector2(0.5f, 1);
    public static float maxAngle = 360;
    public static Vector3 startPosition = new Vector3(-3, -2, 0);
    public static Color selected = new Color(0, 255, 255);
    public static Color nonSelected = new Color(0, 0, 0);
    private static bool playing = false;
    public static bool endRules = false;
    public static bool Playing {
        get => playing;
        set {
            playing = value;
            GameObject.Find("addArrow").GetComponent<Button>().interactable = !playing;
        }
    }
}
