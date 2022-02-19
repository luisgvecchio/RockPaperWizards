using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void UpdateTurn();

public class PlayerTurnManager : MonoBehaviour
{
    public GameObject[] uIElements;
    public EndOfMatchManager endOfMatchManager;
    public event UpdateTurn OnTurnEnd;

    public int turnNumber;

    private void Start()
    {
        StartTurn();
        OnTurnEnd += StartTurn;
    }

    public void StartTurn()
    {
        if (endOfMatchManager.endOfMatch != true)
        {
            if (GameData.Instance.userGameData.playerNumber == 1 && gameObject.tag == "P1")
            {
                Debug.Log(GameData.Instance.gameData.turnState);

                if(GameData.Instance.gameData.turnState == 0)
                {
                    Debug.Log("After Checking turnState = 0");
                    ActivateUI();
                }
            }
            else if (GameData.Instance.userGameData.playerNumber == 2 && gameObject.tag == "P2")
            {
                if (GameData.Instance.gameData.turnState == 1)
                {
                    ActivateUI();
                }
            }
        }
    }
    public void EndTrun()
    {
        DeactivateUI();
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

    public void EndOfTurnUpdate()
    {
        if (GameData.Instance.userGameData.playerNumber == 1 && gameObject.tag == ("P1"))
        {
            UpdateTurn();
            UpdateCurrentAttack();
        }
        else if (GameData.Instance.userGameData.playerNumber == 2 && gameObject.tag == ("P2"))
        {
            UpdateTurn();
            UpdateCurrentAttack();
        }

        SaveTurnChanges();
    }

    public void UpdateTurn()
    {
        GameData.Instance.gameData.turnState++;

        if (GameData.Instance.gameData.turnState > 3) GameData.Instance.gameData.turnState = 0;

        OnTurnEnd?.Invoke();
    }
    private void UpdateCurrentAttack()
    { 
        GameData.Instance.userGameData.currentAttack = GetComponent<PlayerAttacks>().chosenattack;
    }

    public void SaveTurnChanges()
    {
        GameData.Instance.SaveUserGameData();

        GameData.Instance.SaveGameData();
    }    
}
