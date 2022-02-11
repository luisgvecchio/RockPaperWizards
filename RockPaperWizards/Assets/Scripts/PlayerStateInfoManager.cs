using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInfoManager : MonoBehaviour
{
    public EndOfMatchManager endOfMatch;
    private static PlayerInfo playerInfo;
    static string userPath;

    private void Start()
    {
        userPath = "users/" + FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        GetComponent<PlayerTurnManager>().OnTurnEnd += EndOfTurnUpdate;
    }

    public void EndOfTurnUpdate()
    {
        playerInfo.turnNumber = GetComponent<PlayerTurnManager>().turnNumber;
        playerInfo.currentAttack = GetComponent<PlayerAttacks>().chosenattack;

        SaveData();
    }

    public static void SaveData()
    {
        SaveAndLoadManager.Instance.SaveData(userPath, JsonUtility.ToJson(playerInfo));
    }
}
