using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameCurrentTurnManager : MonoBehaviour
{
    public PlayerTurnManager player1, player2;
    public PlayerName player1Name, player2Name;
    TextMeshProUGUI currentTurn;

    private void Start()
    {
        currentTurn = GetComponent<TextMeshProUGUI>();
        DisplayP1Name();
    }

    public void DisplayP1Name()
    {
        currentTurn.text = player1Name.player1Name + " chose attack!";
    }

    public void DisplayP2Name()
    {
        currentTurn.text = player2Name.player2Name + " chose attack!";
    }
}
