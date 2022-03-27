using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAnimationsManager : MonoBehaviour
{
    int spriteNumber;

    void Awake()
    {
        CheckSpriteNumber();
        ChangeWizardAnimationProvider();
    }

    private void CheckSpriteNumber()
    {
        if (GameData.Instance.userGameData.playerNumber.Equals(1) && gameObject.tag.Equals("P1"))
            spriteNumber = GameData.Instance.userGameData.wizard;

        else if (GameData.Instance.userGameData.playerNumber.Equals(2) && gameObject.tag.Equals("P2"))
            spriteNumber = GameData.Instance.userGameData.wizard;

        else if (GameData.Instance.userGameData.playerNumber.Equals(2) && gameObject.tag.Equals("P1"))
            spriteNumber = GameData.Instance.gameData.players[0].wizard;

        else if (GameData.Instance.userGameData.playerNumber.Equals(1) && gameObject.tag.Equals("P2"))
        {
            try
            {
                spriteNumber = GameData.Instance.gameData.players[1].wizard;
            }
            catch
            {
                SubscribeToP2WizardChanges();
            }
        }
    }
    private void ChangeWizardAnimationProvider()
    {
        if (spriteNumber == 0 && gameObject.tag.Equals("P1"))
        {
            ServiceLocator.SetAnimationProviderP1(new WizardOneP1AnimationProvider());
        }
        else if (spriteNumber == 0 && gameObject.tag.Equals("P2"))
        {
            ServiceLocator.SetAnimationProviderP2(new WizardOneP2AnimationProvider());
        }

        else if (spriteNumber == 1 && gameObject.tag.Equals("P1"))
        {
            ServiceLocator.SetAnimationProviderP1(new WizardTwoP1AnimationProvider());
        }
        else if (spriteNumber == 1 && gameObject.tag.Equals("P2"))
        {
            ServiceLocator.SetAnimationProviderP2(new WizardTwoP2AnimationProvider());
        }
    }

    private void SubscribeToP2WizardChanges()
    {
        string gameIdPath = GameData.Instance.gameData.gameId;

        FirebaseDatabase.DefaultInstance.RootReference.Child("games/").Child(gameIdPath + "/").Child("players").ValueChanged += RunP2WizardNumberUpdate;
    }

    private void UnsubscribeToP2WizardChanges()
    {
        string gameIdPath = GameData.Instance.gameData.gameId;

        FirebaseDatabase.DefaultInstance.RootReference.Child("games/").Child(gameIdPath + "/").Child("players").ValueChanged -= RunP2WizardNumberUpdate;

        Debug.Log("unsubscribed");
    }

    void RunP2WizardNumberUpdate(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        try
        {
            string gameIdPath = GameData.Instance.gameData.gameId;

            SaveAndLoadManager.Instance.LoadData("games/" + gameIdPath + "/", GameData.Instance.LoadGameData);

            if (GameData.Instance.gameData.players?[1] != null)
            {
                CheckSpriteNumber();
                ChangeWizardAnimationProvider();
                UnsubscribeToP2WizardChanges();
            }
        }
        catch
        {
        }
    }
}