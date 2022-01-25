using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
    public bool myTurn;
    public GameObject[] uIElements;

    public void StartTurn()
    {
        myTurn = true;
        ActivateUI();
    }


    public void EndTrun()
    {
        myTurn = false;
        DeactivateUI();
    }

    private void ActivateUI()
    {
        foreach (var elements in uIElements)
        {
            elements.SetActive(true);
        }
    }
    private void DeactivateUI()
    {
        foreach (var elements in uIElements)
        {
            elements.SetActive(false);
        }
    }
}
