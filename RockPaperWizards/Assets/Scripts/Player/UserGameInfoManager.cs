using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGameInfoManager : MonoBehaviour
{
    public EndOfMatchManager endOfMatch;
    static string userPath;

    private void Start()
    {
        userPath = "users/" + FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        GetComponent<PlayerTurnManager>().OnTurnEnd += EndOfTurnUpdate;
    }

    public void EndOfTurnUpdate()
    {
        GameData.Instance.userGameData.turnNumber = GetComponent<PlayerTurnManager>().turnNumber;
        GameData.Instance.userGameData.currentAttack = GetComponent<PlayerAttacks>().chosenattack;

        GameData.Instance.SaveUserGameData();
    }
}
