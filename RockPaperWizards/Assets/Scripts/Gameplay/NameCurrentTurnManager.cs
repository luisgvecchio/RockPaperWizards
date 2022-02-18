using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NameCurrentTurnManager : MonoBehaviour
{
    public TextMeshProUGUI currentTurn;
    public PlayerTurnManager p1, p2;

    string p1Name;
    string p2Name;
    int turnstate;

    private void Start()
    {
        DisplayPlayerName();
        p1.OnTurnEnd += DisplayPlayerName;
        p2.OnTurnEnd += DisplayPlayerName;
    }

    public void DisplayPlayerName()
    {
        if (GameData.Instance.userGameData.playerNumber == 1)
        {
            DeclareVariables();

            switch (turnstate)
            {
                case 0:
                    {
                        currentTurn.text = p1Name + " choose attack!";
                        break;
                    }
                case 1:
                    {
                        if(p2Name != null)
                            currentTurn.text = "Waiting for " + p2Name;
                        else 
                            currentTurn.text = "Waiting for opponent";
                        break;
                    }
                case 2:
                    {
                        currentTurn.text = null;
                        break;
                    }
            }
        }

        else if (GameData.Instance.userGameData.playerNumber == 2)
        {
            DeclareVariables();

            switch (turnstate)
            {
                case 0:
                    {
                        currentTurn.text = "Waiting for " + p1Name;
                        break;
                    }
                case 1:
                    {
                        currentTurn.text = p2Name + " choose attack!";
                        break;
                    }
                case 2:
                    {
                        currentTurn.text = "Waiting for " + p1Name;
                        break;
                    }
            }
        }
    }

    private void DeclareVariables()
    {
        p1Name = GameData.Instance.gameData.players[0].name;
        p2Name = GameData.Instance.gameData.players[1].name;
        turnstate = GameData.Instance.gameData.turnState;
    }
}
