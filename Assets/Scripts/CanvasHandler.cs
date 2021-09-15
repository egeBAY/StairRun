using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{
    public Text GameOverText;
    public Text WinText;

    private void Start()
    {
        GameOverText.enabled = false;
        WinText.enabled = false;
    }

    public void ShowGameOverText()
    {
        GameOverText.enabled = true;
    }

    public void ShowWinText()
    {
        WinText.enabled = true;
    }




}
