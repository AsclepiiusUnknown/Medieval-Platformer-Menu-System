using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public CubeRotator cube;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(false);
                pauseMenu.SetActive(true);
            }
            else
            {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }

        }
    }

    public void Resume()
    {
        Click();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void RestartLevel()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SaveCube()
    {
        SaveSystem.SaveCube(cube);

        try
        {
        }
        catch
        {
            if (cube == null)
                Debug.LogError("**ERROR CAUGHT** \n Refrence to 'cube' has not been set so save was unsuccessful.");
            else
                Debug.LogError("**ERROR CAUGHT** \n Unknown error caught from Ln:62.");
        }
    }

    public void Quit()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    void Click()
    {
        FindObjectOfType<AudioManager>().Play("Click01");
    }
}