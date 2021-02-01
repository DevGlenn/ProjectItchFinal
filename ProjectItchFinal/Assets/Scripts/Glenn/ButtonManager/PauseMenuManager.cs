using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject creditsMenu;

    private void Update()
    {
        Pause();
    }
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            pauseMenu.SetActive(true); //pauze menu is te zien
            Time.timeScale = 0; //freeze de game
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false); //het pauze menu is niet meer zichtbaar
        Time.timeScale = 1; //continue de game
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0); // laad het hoofdmenu
    }

    public void GoToSettingsMenu()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true); // Zet het hoofdmenu aan
    }

    public void SettingsToPause()
    {
        settingsMenu.SetActive(false); 
        pauseMenu.SetActive(true);
    }
    public void SettingsToCredits()
    {
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
    public void CreditsToSettings()
    {
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
