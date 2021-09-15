using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public bool gameIsPaused = false;
    


    private void Update()
    {
        if(gameIsPaused & Input.GetMouseButtonDown(0))
        {
            Restart();
        }
    }

    public void GameOver()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            FindObjectOfType<CanvasHandler>().ShowGameOverText();
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
    }

    public void WinState()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        FindObjectOfType<CanvasHandler>().ShowWinText();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
