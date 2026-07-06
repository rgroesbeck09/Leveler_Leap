using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        creditsPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}


