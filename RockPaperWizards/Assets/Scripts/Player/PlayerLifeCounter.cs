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
        else if (GameData.Instance.userGameData.playerNumber == 2 && gameObject.tag == "P2")
        {
            Debug.Log("P2 Update");
            UpdateP2LivesUI();
            otherPlayer.UpdateP1LivesUI();
        }
    }
    public void UpdateP1LivesUI()
    {
        int length = livesArray.Count - 1;
        int difference = livesArray.Count - GameData.Instance.gameData.players[0].lives;

        if (GameData.Instance.gameData.players[0].lives < livesArray.Count)
        {
            for (int i = length; i > length - difference; i--)
            {
                Destroy(livesArray[i]);
                livesArray.RemoveAt(i);
            }
        }
    }
    public void UpdateP2LivesUI()
    {
        int length = livesArray.Count - 1;
        int difference = livesArray.Count - GameData.Instance.gameData.players[1].lives;

        if (GameData.Instance.gameData.players[1].lives < livesArray.Count)
        {
            for (int i = length; i > length - difference; i--)
            {
                Destroy(livesArray[i]);
                livesArray.RemoveAt(i);
            }
        }
    }
    public void P1TakesDamage()
    {
        GameData.Instance.gameData.players[0].lives--;
        GameData.Instance.SaveGameData();
    }

    public void P2TakesDamage()
    {
        GameData.Instance.gameData.players[1].lives--;
        GameData.Instance.SaveGameData();
    }



}
