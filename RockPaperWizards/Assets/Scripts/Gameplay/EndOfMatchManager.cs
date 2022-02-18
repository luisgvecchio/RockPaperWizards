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
        if (GameData.Instance.userGameData.playerNumber == 1 && GameData.Instance.userGameData.lives == 0)
        {
            endOfMatch = true;
            resultText.DeclareWinnerP2();
            ManageButtons();
            congratsScript.SetCongratulationsMessage(resultText.winnerOfTheMatch);
        }
        else if (GameData.Instance.userGameData.playerNumber == 2 && GameData.Instance.userGameData.lives == 0)
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
