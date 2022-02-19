using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject turnPlate;
    public GameObject recopilationPanel;
    public EndOfMatchManager endOfMatchManager;

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

        GameData.Instance.gameData = JsonUtility.FromJson<GameInfo>(args.Snapshot.GetRawJsonValue());

        CheckIfTurnChanged();
    }

    void CheckIfTurnChanged()
{
        if (GameData.Instance.gameData.turnState.Equals(2) && GameData.Instance.userGameData.playerNumber == 2)
        {
            TurnOffTurnPlate();
            TurnOnRecopilationPanel();
        }
        else if (GameData.Instance.gameData.turnState.Equals(2) && GameData.Instance.userGameData.playerNumber == 1)
        {
            TurnOffTurnPlate();
            TurnOnRecopilationPanel();
        }
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

            if(GameData.Instance.userGameData.playerNumber.Equals(1))
            {
                playerTurnP1.UpdateTurn();
                playerTurnP1.SaveTurnChanges();
                playerTurnP1.StartTurn();
            }
        }
    }
    public void TurnOnRecopilationPanel()
    {
        recopilationPanel.SetActive(true);
    }
}
