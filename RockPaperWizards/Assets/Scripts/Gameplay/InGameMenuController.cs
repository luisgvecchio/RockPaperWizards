using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuController : MonoBehaviour
{
    public GameObject inGameMenu, restartPanel, mainMenuPanel;
   
    public void OpenInGameMenu()
    {
        inGameMenu.SetActive(true);
    }
    public void Resume()
    {
        inGameMenu.SetActive(false);
    }
    public void OpenRestartPanel()
    {
        restartPanel.SetActive(true);
    }
    public void CloseRestartPanel()
    {
        restartPanel.SetActive(false);
    }
    public void OpenMainMenuPanel()
    {
        mainMenuPanel.SetActive(true);
    }
    public void CloseMainMenuPanel()
    {
        mainMenuPanel.SetActive(false);
    }
}
