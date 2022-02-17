using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameSelect : MonoBehaviour
{
    public void CreateNewGame()
    {
        GameInfo newGame = new GameInfo();

        string key = SaveAndLoadManager.Instance.GetKey("games/");

        newGame.gameName = "Name of game";
        newGame.gameId = key;
        newGame.openPlayerSlots = 2;


        SaveAndLoadManager.Instance.SaveData("games/" + key, JsonUtility.ToJson(newGame));
    }
}
