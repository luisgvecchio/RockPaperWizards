using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfMatchManager : MonoBehaviour
{
    public PlayerLifeCounter player1, player2;
    public ResultTextManager resultText;
    public GameObject pressAnywhereButton, rematchButton, mainMenuButton, congratulationsMessage;
    public CongratulationsTextManager congratsScript;

    public bool endOfMatch;

    public void CheckIfEndOfMatch()
    {
        if (GameData.Instance.gameData.players[0].lives.Equals(0))
        {
            endOfMatch = true;
            resultText.DeclareWinnerP2();
            ManageButtons();
            congratsScript.SetCongratulationsMessage(resultText.winnerOfTheMatch);
        }
        else if (GameData.Instance.gameData.players[1].lives.Equals(0))
        {
            endOfMatch = true;
            resultText.DeclareWinnerP1();
            ManageButtons();
            congratsScript.SetCongratulationsMessage(resultText.winnerOfTheMatch);
        }
    }
    void ManageButtons()
    {
        pressAnywhereButton.SetActive(false);
        rematchButton.SetActive(true);
        mainMenuButton.SetActive(true);
        congratulationsMessage.SetActive(true);
    }
}
