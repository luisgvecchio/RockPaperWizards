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

    /*Added an OnDestroy event only to unsuscribe from the Firebases ValueChanged. If I log in with an user, log off, log in with another and start a match I get an error;

        "UnityEngine.MissingReferenceException: The object of type 'PlayerTurnManager' has been destroyed but you are still trying to access it.
        Your script should either check if it is null or you should not destroy the object."

        It seems like Firebase wants to reference the PlayerTurn object´s referece of the previous player still.
    */

    private void OnDestroy()
{
    FirebaseDatabase.DefaultInstance.RootReference.Child("games/").Child(GameData.Instance.gameData.gameId).ValueChanged -= StartTurn;
    Debug.Log("Unsuscribed PlayerTurn");
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
    Debug.Log(GameData.Instance.userGameData.playerNumber);

    Debug.Log(gameObject.tag);

    if (GameData.Instance.userGameData.playerNumber == 1 && gameObject.tag == "P1")
    {
        if (GameData.Instance.gameData.turnState == 0 && !endOfMatchManager.endOfMatch)
        {
            ActivateUI();

            if (ServiceLocator.GetAnimationProviderP1() != null)
                ServiceLocator.GetAnimationProviderP1().PlayIdleAnimation();
        }
    }

    else if (GameData.Instance.userGameData.playerNumber == 2 && gameObject.tag == "P2")
    {
        if (GameData.Instance.gameData.turnState == 1)
        {
            ActivateUI();
            if (ServiceLocator.GetAnimationProviderP1() != null)
                ServiceLocator.GetAnimationProviderP2().PlayIdleAnimation();
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
