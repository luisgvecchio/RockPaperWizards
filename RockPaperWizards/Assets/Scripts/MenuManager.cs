using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu, settings, battleHistory, choseProfile;
    
    public void CloseMainMenu()
    {
        mainMenu.SetActive(false);
    }
    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
    }
    public void CloseSettings()
    {
        settings.SetActive(false);
    }
    public void OpenSettings()
    {
        settings.SetActive(true);
    }
    public void CloseBattleHistory()
    {
        battleHistory.SetActive(false);
    }
    public void OpenBattleHistory()
    {
        battleHistory.SetActive(true);
    }
    public void CloseChoseprofile()
    {
        choseProfile.SetActive(false);
    }
    public void OpenChoseProfile()
    {
        choseProfile.SetActive(true);
    }
}
