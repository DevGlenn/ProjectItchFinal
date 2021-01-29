using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMan : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject mainButtons;

    private void Update()
    {
        if (SceneManager.sceneCount == 1)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Pause();
            }
        }
        if (SceneManager.sceneCount == 2)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Pause();
            }
        }
        if (SceneManager.sceneCount == 3)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        pauseMenu.SetActive(true); //pauze menu is te zien
        Time.timeScale = 0; //freeze de game
    }
    public void Resume()
    {
        pauseMenu.SetActive(false); //het pauze menu is niet meer zichtbaar
        Time.timeScale = 1; //continue de game
    }

    public void GoToMainMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
        mainButtons.SetActive(true);
        titleScreen.SetActive(true);
    }
    public void StartLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void RestartLevel()
    {
        if (SceneManager.sceneCount == 1) //als je in de eerste scene in de buildIndex zit
        {
            SceneManager.LoadScene("Level1"); //reload de scene
        }
        else if (SceneManager.sceneCount == 2)
        {
            SceneManager.LoadScene("Level2"); //reload de scene
        }
        else if (SceneManager.sceneCount == 3)
        {
            SceneManager.LoadScene("Level3"); //reload de scene
        }

    }

    public void GoToSettingsMenu()
    {
        settingsMenu.SetActive(true);
        titleScreen.SetActive(false);
        mainMenu.SetActive(false);
        mainButtons.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
