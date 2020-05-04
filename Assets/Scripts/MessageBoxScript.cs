using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoxScript : MonoBehaviour
{
    public GameObject canvas;
    public Text textField;
    public Button playButton;
    void Start()
    {
        canvas.SetActive(false);
    }

    public void Show(string message)
    {
        textField.text = message;
        canvas.SetActive(true);
        playButton.interactable = false;
    }

    public void NotPlaying()
    {
        Globals.Playing = false;
        playButton.interactable = true;
        canvas.SetActive(false);
    }
}
