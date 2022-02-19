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
    public PlayerTurnManager playerTurn;

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

        GameData.Instance.gameData = JsonUtility.FromJson<GameInfo>(args.Snapshot.GetRawJsonValue());

        CheckCorrectTurnState();

    }

        private void CheckCorrectTurnState()
    {
        if (GameData.Instance.gameData.turnState.Equals(2))
        {
            if(GameData.Instance.userGameData.playerNumber == 2)
            {
                RunResolution();
                CallActionsAfterAttacks();
                Debug.Log("Befor UpdateTurn++");
                playerTurn.UpdateTurn();
                playerTurn.SaveTurnChanges();
            }
        }
        else if (GameData.Instance.gameData.turnState.Equals(3))
        {
            if (GameData.Instance.userGameData.playerNumber == 1)
            {
                RunResolution();
                CallActionsAfterAttacks();
            }
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
    }

}
