using UnityEngine;
using System;
using Firebase.Database;

public enum Resolution
{
    FireVsFire,
    FireVsWater,
    FireVsPlant,
    WaterVsWater,
    WaterVsFire,
    WaterVsPlant,
    PlantVsPlant,
    PlantVsFire,
    PlantVsWater
}

public class AttackResolutionManager : MonoBehaviour
{
    public PlayerAttacks player1Attack, player2Attack;
    public PlayerLifeCounter player1Lives, player2Lives;
    public ResultTextManager resultText;
    public Resolution clash;

    int resolutionAlreadyRun;

    private void Start()
    {
        CheckCorrectTurnState();
        FirebaseDatabase.DefaultInstance.RootReference.Child("games/").Child(GameData.Instance.gameData.gameId).ValueChanged += CheckCorrectTurnState;
    }

    void CheckCorrectTurnState(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        GameInfo gameInfo = JsonUtility.FromJson<GameInfo>(args.Snapshot.GetRawJsonValue());

        GameData.Instance.gameData.turnState = gameInfo.turnState;
        CheckCorrectTurnState();

    }

        private void CheckCorrectTurnState()
    {
        RunResolutionLoop();

        if (GameData.Instance.gameData.turnState.Equals(2))
        {
            if (GameData.Instance.userGameData.playerNumber == 2 && resolutionAlreadyRun == 1)
            {
                RunResolution();
                CallActionsAfterAttacks();
                GameData.Instance.SaveGameData();
            }
        }
        else if (GameData.Instance.gameData.turnState.Equals(3))
        {
            if (GameData.Instance.userGameData.playerNumber == 1 && resolutionAlreadyRun == 1)
            {
                RunResolution();
                CallActionsAfterAttacks();
                GameData.Instance.SaveGameData();
            }
        }
    }

    public void RestartResolutionLoop()
    {
        resolutionAlreadyRun = 0;
    }

    private void RunResolutionLoop()
    {
        var turnState = GameData.Instance.gameData.turnState;
        var playerNumber = GameData.Instance.userGameData.playerNumber;

        if (turnState.Equals(2) && playerNumber == 2)
        {
            resolutionAlreadyRun++;
            if (resolutionAlreadyRun > 2) resolutionAlreadyRun = 2;
        }
        else if (turnState.Equals(3) && playerNumber == 1)
        {
            resolutionAlreadyRun++;
            if (resolutionAlreadyRun > 2) resolutionAlreadyRun = 2;
        }
    }

    public string GetAttacks()
    {
        var p1Attack = GameData.Instance.gameData.players[0].currentAttack;
        var p2Attack = GameData.Instance.gameData.players[1].currentAttack;

        string resolution = p1Attack + "Vs" + p2Attack;
        return resolution;
    }
    public void CheckResolution(string resolution)
    {
        clash = (Resolution)Enum.Parse(typeof(Resolution), resolution);
    }
    public void RunResolution()
    {
        CheckResolution(GetAttacks());
    }
    public void CallActionsAfterAttacks()
    {
        switch (clash)
        {
            case Resolution.FireVsFire:
                {
                    resultText.NoDamage();
                    break;
                }
            case Resolution.FireVsWater:
                {
                    resultText.SetP1GotHit();
                    player1Lives.P1TakesDamage();
                    player1Lives.UpdateP1LivesUI();
                    break;
                }
            case Resolution.FireVsPlant:
                {
                    resultText.SetP2GotHit();
                    player2Lives.P2TakesDamage();
                    player2Lives.UpdateP2LivesUI();
                    break;
                }
            case Resolution.WaterVsWater:
                {
                    resultText.NoDamage();
                    break;
                }
            case Resolution.WaterVsFire:
                {
                    resultText.SetP2GotHit();
                    player2Lives.P2TakesDamage();
                    player2Lives.UpdateP2LivesUI();
                    break;
                }
            case Resolution.WaterVsPlant:
                {
                    resultText.SetP1GotHit();
                    player1Lives.P1TakesDamage();
                    player1Lives.UpdateP1LivesUI();
                    break;
                }
            case Resolution.PlantVsPlant:
                {
                    resultText.NoDamage();
                    break;
                }
            case Resolution.PlantVsFire:
                {
                    resultText.SetP1GotHit();
                    player1Lives.P1TakesDamage();
                    player1Lives.UpdateP1LivesUI();
                    break;
                }
            case Resolution.PlantVsWater:
                {
                    resultText.SetP2GotHit();
                    player2Lives.P2TakesDamage();
                    player2Lives.UpdateP2LivesUI();
                    break;
                }
        }
                Debug.Log("Actions Called");
    }

}
