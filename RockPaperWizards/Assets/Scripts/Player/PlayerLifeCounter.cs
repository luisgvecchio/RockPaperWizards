using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeCounter : MonoBehaviour
{
    public List<GameObject> livesArray;
    public PlayerLifeCounter otherPlayer;

    private void Start()
    {

        if (GameData.Instance.userGameData.playerNumber == 1 && gameObject.tag == "P1")
        {
            UpdateP1LivesUI();
            otherPlayer.UpdateP2LivesUI();
        }
        else if (GameData.Instance.userGameData.playerNumber == 1 && gameObject.tag == "P2")
        {
            UpdateP2LivesUI();
            otherPlayer.UpdateP1LivesUI();
        }
    }
    public void UpdateP1LivesUI()
    {
        int length = livesArray.Count - 1;
        int difference = length - GameData.Instance.gameData.players[0].lives;

        if (GameData.Instance.gameData.players[0].lives < length)
        {
            for (int i = length - 1; i > length - difference ; i--)
            {
                Destroy(livesArray[i - 1]);
                livesArray.RemoveAt(i - 1);
            }
        }
    }
    public void UpdateP2LivesUI()
    {
        int length = livesArray.Count - 1;
        int difference = length - GameData.Instance.gameData.players[1].lives;

        if (GameData.Instance.gameData.players[1].lives < length)
        {
            for (int i = length - 1; i > length - difference; i--)
            {
                Destroy(livesArray[i - 1]);
                livesArray.RemoveAt(i - 1);
            }
        }
    }
    public void P1TakesDamage()
    {
        if (GameData.Instance.userGameData.playerNumber == 1)
        {
            GameData.Instance.userGameData.lives--;

            GameData.Instance.SaveUserGameData();
            GameData.Instance.SaveGameData();
        }
    }

    public void P2TakesDamage()
    {
        if (GameData.Instance.userGameData.playerNumber == 2)
        {
            GameData.Instance.userGameData.lives--;

            Debug.Log("Getting hit");

            GameData.Instance.SaveUserGameData();
            GameData.Instance.SaveGameData();
        }
    }



}
