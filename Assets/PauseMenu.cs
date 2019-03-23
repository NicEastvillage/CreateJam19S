using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        pauseGane();
    }

    private void pauseGane()
    {
        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Joystick1Button9))
        {
            if (gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("Game");
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        SceneManager.LoadScene("Pause_Menu_Scene");
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
