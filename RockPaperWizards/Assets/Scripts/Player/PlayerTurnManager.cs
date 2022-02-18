using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void StartTurn();
public delegate void EndTurn();

public class PlayerTurnManager : MonoBehaviour
{
    public GameObject[] uIElements;
    public EndOfMatchManager endOfMatchManager;

    public event StartTurn OnTurnStart;
    public event EndTurn OnTurnEnd;

    public int turnNumber;

    public void StartTurn()
    {
        if (endOfMatchManager.endOfMatch != true)
        {
            ActivateUI();
        }
        OnTurnStart?.Invoke();
    }
    public void EndTrun()
    {
        DeactivateUI();
        AddTurnCounter();

        EndOfTurnUpdate();
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

    private void AddTurnCounter() { turnNumber++; }
    public void EndOfTurnUpdate()
    {
        if (GameData.Instance.userGameData.playerNumber == 1 && gameObject.tag == ("P1"))
        {
            UpdateTurnAndCurrentAttack();
        }
        else if (GameData.Instance.userGameData.playerNumber == 2 && gameObject.tag == ("P2"))
        {
            UpdateTurnAndCurrentAttack();
        }

        

        SaveTurnChanges();
    }

    private void UpdateTurnAndCurrentAttack()
    {
        GameData.Instance.userGameData.turnNumber = turnNumber;
        GameData.Instance.userGameData.currentAttack = GetComponent<PlayerAttacks>().chosenattack;
    }

    private void SaveTurnChanges()
    {
        GameData.Instance.SaveUserGameData();

        GameData.Instance.SaveGameData();
    }    
}
