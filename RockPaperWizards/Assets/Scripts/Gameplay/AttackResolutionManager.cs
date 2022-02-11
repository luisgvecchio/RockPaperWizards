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
    public void SetLivesAfterAttacks()
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
                    player1Lives.lives--;
                    player1Lives.UpdateLivesUI();
                    break;
                }
            case Resolution.FireVsPlant:
                {
                    resultText.SetP2GotHit();
                    player2Lives.lives--;
                    player2Lives.UpdateLivesUI();
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
                    player2Lives.lives--;
                    player2Lives.UpdateLivesUI();
                    break;
                }
            case Resolution.WaterVsPlant:
                {
                    resultText.SetP1GotHit();
                    player1Lives.lives--;
                    player1Lives.UpdateLivesUI();
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
                    player1Lives.lives--;
                    player1Lives.UpdateLivesUI();
                    break;
                }
            case Resolution.PlantVsWater:
                {
                    resultText.SetP2GotHit();
                    player2Lives.lives--;
                    player2Lives.UpdateLivesUI();
                    break;
                }

        }
    }

}
