using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject turnPlate;
    public GameObject recopilationPanel;
    public EndOfMatchManager endOfMatchManager;
    public AttackResolutionManager attackResolution;

    public PlayerTurnManager playerTurnP2, playerTurnP1;

    private void Start()
    {
        FirebaseDatabase.DefaultInstance.RootReference.Child("games/").Child(GameData.Instance.gameData.gameId).ValueChanged += CheckIfTurnChanged;
    }

    void CheckIfTurnChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        GameInfo gameInfo = JsonUtility.FromJson<GameInfo>(args.Snapshot.GetRawJsonValue());

        GameData.Instance.gameData.turnState = gameInfo.turnState;

        CheckIfTurnChanged(gameInfo);
    }

    void CheckIfTurnChanged(GameInfo gameInfo)
    {
        var turnState = GameData.Instance.gameData.turnState;
        var playerNumber = GameData.Instance.userGameData.playerNumber;

        if (turnState.Equals(0) && playerNumber.Equals(1))
        {
            LoadGameData(gameInfo);
        }
        else if (turnState.Equals(1) && playerNumber.Equals(2))
        {
            LoadGameData(gameInfo);
        }

        if (turnState.Equals(2) && playerNumber == 2)
        {
            LoadGameData(gameInfo);
            TurnOffTurnPlate();
            TurnOnRecopilationPanel();
        }
        else if (turnState.Equals(3) && playerNumber == 1)
        {
            LoadGameData(gameInfo);
            TurnOffTurnPlate();
            TurnOnRecopilationPanel();
        }
    }

    private static void LoadGameData(GameInfo gameInfo)
    {
        GameData.Instance.gameData = gameInfo;
    }

    public void TurnOnTurnPlate()
    {
        if (endOfMatchManager.endOfMatch != true)
        {
            turnPlate.SetActive(true);
        }
    }
    public void TurnOffTurnPlate()
    {
        turnPlate.SetActive(false);
    }
    public void TurnOffRecopilationPanel()
    {
        if (endOfMatchManager.endOfMatch != true)
        {
            recopilationPanel.SetActive(false);

            attackResolution.RestartResolutionLoop();
            playerTurnP1.UpdateTurn();
            playerTurnP1.SaveTurnChanges();

            if (GameData.Instance.userGameData.playerNumber.Equals(1))
            {
                playerTurnP1.StartTurn();
            }
        }
    }
    public void TurnOnRecopilationPanel()
    {
        recopilationPanel.SetActive(true);
    }
}
