using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Firebase.Database;
using System;

public class PlayersNames : MonoBehaviour
{
    public TextMeshProUGUI p1Label, p2Label;

    public string player1Name;
    public string player2Name;

    Vector3 offset;

    private void Start()
    {
        player1Name = GameData.Instance.gameData.players[0].name;
        player2Name = "?????";

        p1Label.text = player1Name;
        p2Label.text = player2Name;

        FirebaseDatabase.DefaultInstance.RootReference.Child("games/").Child(GameData.Instance.gameData.gameId).ValueChanged += CheckP2Name;
    }

    private void CheckP2Name(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        try
        {
            GameInfo gameInfo = JsonUtility.FromJson<GameInfo>(args.Snapshot.GetRawJsonValue());

            if (gameInfo.players?[1] != null)
            {
                player2Name = gameInfo.players[1].name;

                p2Label.text = player2Name;

                FirebaseDatabase.DefaultInstance.RootReference.Child("games/").Child(GameData.Instance.gameData.gameId).ValueChanged -= CheckP2Name;
            }
        }
        catch
        { }
    }
}
