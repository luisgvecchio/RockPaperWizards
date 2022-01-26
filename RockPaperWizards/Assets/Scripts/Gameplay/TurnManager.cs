using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject turnPlate;
    public GameObject recopilationPanel;
    public EndOfMatchManager endOfMatchManager;

    public void TurnOnTurnPlate()
    {
        if (endOfMatchManager.endOfMatch != true)
        {
            turnPlate.SetActive(true);
        }
    }
    public void TurnOffTurnPlate()
    {
        turnPlate.SetActive(false);
    }
    public void TurnOffRecopilationPanel()
    {
        if (endOfMatchManager.endOfMatch != true)
        {
            recopilationPanel.SetActive(false);
        }
    }
    public void TurnOnRecopilationPanel()
    {
        recopilationPanel.SetActive(true);
    }
}
