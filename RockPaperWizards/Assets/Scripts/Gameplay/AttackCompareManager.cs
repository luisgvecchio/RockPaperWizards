using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackCompareManager : MonoBehaviour
{
    public PlayerAttacks player1Attack, player2Attack;
    public PlayerLifeCounter player1Lives, player2Lives;

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
        Debug.Log(clash);
    }

    public void SetLivesAfterAttacks()
    {
        switch (clash)
        {
            case Resolution.FireVsFire:
                {
                    break;
                }
            case Resolution.FireVsWater:
                {
                    player1Lives.lives--;
                    break;
                }
            case Resolution.FireVsPlant:
                {
                    player2Lives.lives--;
                    break;
                }
            case Resolution.WaterVsWater:
                {
                    break;
                }
            case Resolution.WaterVsFire:
                {
                    player2Lives.lives--;
                    break;
                }
            case Resolution.WaterVsPlant:
                {
                    player1Lives.lives--;
                    break;
                }
            case Resolution.PlantVsPlant:
                {
                    break;
                }
            case Resolution.PlantVsFire:
                {
                    player1Lives.lives--;
                    break;
                }
            case Resolution.PlantVsWater:
                {
                    player2Lives.lives--;
                    break;
                }

        }
    }

}
