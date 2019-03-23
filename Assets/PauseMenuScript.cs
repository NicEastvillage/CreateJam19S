using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        pauseGame();
    }

    public void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button9) || Input.GetKeyDown(KeyCode.Joystick2Button9)) 
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Debug.Log("Paused");
                Pause();
            }
        }
    }

    public void Resume()
    {
        audiomanager.instance.PlayGamebegin();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        
    }

    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");

    }

    public void quitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}

