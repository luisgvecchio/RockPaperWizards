using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultTextManager : MonoBehaviour
{
    public PlayersNames playerNames;
    string p1GotHit, p2GotHit, noDamage, winnerMessage;

    public string winnerOfTheMatch;

    public TextMeshProUGUI resultText;
   
    public void SetP1GotHit()
    {
        p1GotHit = playerNames.player1Name + " got hit!!";
        resultText.text = p1GotHit;
    }
    public void SetP2GotHit()
    {
        p2GotHit = playerNames.player2Name + " got hit!!";
        resultText.text = p2GotHit;
    }
    public void NoDamage()
    {
        noDamage = " No damage this round";
        resultText.text = noDamage;
    }
    public void DeclareWinnerP1()
    {
        winnerOfTheMatch = playerNames.player1Name;
        winnerMessage = "Well, well... Looks like " + winnerOfTheMatch + " it´s the winner of this duel";
        resultText.text = winnerMessage;

    }
    public void DeclareWinnerP2()
    {
        winnerOfTheMatch = playerNames.player2Name;
        winnerMessage = "Well, well... Looks like " + winnerOfTheMatch + " it´s the winner of this duel";
        resultText.text = winnerMessage;
    }


}
