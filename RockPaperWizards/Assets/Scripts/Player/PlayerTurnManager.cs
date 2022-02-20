using Firebase.Database;
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

    private void Start()
    {
        FirebaseDatabase.DefaultInstance.RootReference.Child("games/").Child(GameData.Instance.gameData.gameId).ValueChanged += StartTurn;
        StartTurn();
    }

    void StartTurn(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        GameInfo gameInfo = JsonUtility.FromJson<GameInfo>(args.Snapshot.GetRawJsonValue());

        GameData.Instance.gameData.turnState = gameInfo.turnState;
        StartTurn();
    }

    

    public void StartTurn()
    {
        if (endOfMatchManager.endOfMatch != true)
        {
            if (GameData.Instance.userGameData.playerNumber == 1 && gameObject.tag == "P1")
            {
                if(GameData.Instance.gameData.turnState == 0)
                {
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

        if (GameData.Instance.gameData.turnState > 3)
        {
            GameData.Instance.gameData.turnState = 0;
        }
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
