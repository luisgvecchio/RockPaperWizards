using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfMatchManager : MonoBehaviour
{
    public ResultTextManager resultText;
    public GameObject pressAnywhereButton, mainMenuButton, congratulationsMessage, turnPlate, recopilationPanel, player1;
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
        mainMenuButton.SetActive(true);
        congratulationsMessage.SetActive(true);
        turnPlate.SetActive(false);
        recopilationPanel.SetActive(true);
        player1.SetActive(false);
    }
}
