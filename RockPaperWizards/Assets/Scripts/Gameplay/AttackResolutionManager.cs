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
        FirebaseDatabase.DefaultInstance.RootReference.Child("games/").Child(GameData.Instance.gameData.gameId).Child("turnState").ValueChanged += CheckCorrectTurnState;
    }

    void CheckCorrectTurnState(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        Debug.Log("Checking turn change");

        SaveAndLoadManager.Instance.LoadData("games/" + GameData.Instance.gameData.gameId, GameData.Instance.LoadGameData);


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
                    ServiceLocator.GetAnimationProviderP1().PlayAttackMiddleFireAnimation();
                    ServiceLocator.GetAnimationProviderP2().PlayAttackMiddleFireAnimation();
                    break;
                }
            case Resolution.FireVsWater:
                {
                    resultText.SetP1GotHit();
                    player1Lives.P1TakesDamage();
                    player1Lives.UpdateP1LivesUI();
                    ServiceLocator.GetAnimationProviderP1().PlayAttacktoPlayerFireAnimation();
                    ServiceLocator.GetAnimationProviderP2().PlayAttackMiddleWaterAnimation();

                    break;
                }
            case Resolution.FireVsPlant:
                {

                    resultText.SetP2GotHit();
                    player2Lives.P2TakesDamage();
                    player2Lives.UpdateP2LivesUI();
                    ServiceLocator.GetAnimationProviderP1().PlayAttackMiddleFireAnimation();
                    ServiceLocator.GetAnimationProviderP2().PlayAttacktoPlayerPlantAnimation();
                    break;
                }
            case Resolution.WaterVsWater:
                {
                    resultText.NoDamage();
                    ServiceLocator.GetAnimationProviderP1().PlayAttackMiddleWaterAnimation();
                    ServiceLocator.GetAnimationProviderP2().PlayAttackMiddleWaterAnimation();

                    break;
                }
            case Resolution.WaterVsFire:
                {
                    resultText.SetP2GotHit();
                    player2Lives.P2TakesDamage();
                    player2Lives.UpdateP2LivesUI();

                    Debug.Log(ServiceLocator.GetAnimationProviderP1());
                    Debug.Log(ServiceLocator.GetAnimationProviderP2());


                    ServiceLocator.GetAnimationProviderP1().PlayAttackToPlayerWaterAnimation();
                    ServiceLocator.GetAnimationProviderP2().PlayAttackMiddleFireAnimation();
                    break;
                }
            case Resolution.WaterVsPlant:
                {
                    resultText.SetP1GotHit();
                    player1Lives.P1TakesDamage();
                    player1Lives.UpdateP1LivesUI();
                    ServiceLocator.GetAnimationProviderP1().PlayAttackMiddleWaterAnimation();
                    ServiceLocator.GetAnimationProviderP2().PlayAttacktoPlayerPlantAnimation();
                    break;
                }
            case Resolution.PlantVsPlant:
                {
                    resultText.NoDamage();
                    ServiceLocator.GetAnimationProviderP1().PlayAttackMiddlePlantAnimation();
                    ServiceLocator.GetAnimationProviderP2().PlayAttackMiddlePlantAnimation();
                    break;
                }
            case Resolution.PlantVsFire:
                {
                    resultText.SetP1GotHit();
                    player1Lives.P1TakesDamage();
                    player1Lives.UpdateP1LivesUI();
                    ServiceLocator.GetAnimationProviderP1().PlayAttackMiddlePlantAnimation();
                    ServiceLocator.GetAnimationProviderP2().PlayAttacktoPlayerFireAnimation();
                    break;
                }
            case Resolution.PlantVsWater:
                {
                    resultText.SetP2GotHit();
                    player2Lives.P2TakesDamage();
                    player2Lives.UpdateP2LivesUI();
                    ServiceLocator.GetAnimationProviderP1().PlayAttacktoPlayerPlantAnimation();
                    ServiceLocator.GetAnimationProviderP2().PlayAttackMiddleWaterAnimation();
                    break;
                }
        }
    }

}
