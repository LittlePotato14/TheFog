using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesScript : MonoBehaviour
{
    public GameObject box;
    public Text text;
    private int iter = 0;
    public string[] sentences;
    public GameObject next;
    public bool isFirst = false;

    void Start()
    {
        if(!isFirst)
            box.SetActive(false);
        else
            text.text = sentences[0];
    }

    public void Show()
    {
        iter = 0;
        box.SetActive(true);
        text.text = sentences[0];
    }

    public void OnButton()
    {
        if (iter >= sentences.Length - 1)
        {
            if (next != null)
                next.GetComponent<RulesScript>().Show();
            else
                Globals.endRules = true;
            box.SetActive(false);
            return;
        }
        text.text = sentences[++iter];
    }
}
