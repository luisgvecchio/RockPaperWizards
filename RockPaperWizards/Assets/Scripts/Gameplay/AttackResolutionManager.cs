using UnityEngine;
using System;

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

    public string GetAttacks()
    {
        string resolution = player1Attack.chosenattack + "Vs" + player2Attack.chosenattack;
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
