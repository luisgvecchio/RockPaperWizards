using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameCurrentTurnManager : MonoBehaviour
{
    public PlayerTurnManager player1, player2;
    TextMeshProUGUI currentTurn;

    private void Start()
    {
        currentTurn = GetComponent<TextMeshProUGUI>();
        DisplayP1Name();
    }

    public void DisplayP1Name()
    {
        currentTurn.text = PlayerPrefs.GetString("Player1Name") + " chose attack!";
    }

    public void DisplayP2Name()
    {
        currentTurn.text = PlayerPrefs.GetString("Player2Name") + " chose attack!";
    }
}
