using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtonManager : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject creditsMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void GoToSettingsMenu()
    {
        mainMenu.SetActive(false); 
        settingsMenu.SetActive(true); // Zet het settingsmenu aan
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
