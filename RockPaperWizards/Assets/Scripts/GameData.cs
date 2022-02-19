using Firebase.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameData : MonoBehaviour
{
    private static GameData _instance;
    public static GameData Instance { get { return _instance; } }

    public PlayerInfo playerLocalData;
    public PlayerInGameData userGameData;
    public GameInfo gameData;

    public string userId;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void OnSignIn(string userId)
    {
        this.userId = userId;
        UpdateUserGameDataUserId(userId);
        SaveAndLoadManager.Instance.LoadData("users/" + userId, OnLoadData);
    }

    private void UpdateUserGameDataUserId(string userId)
    {
        userGameData.userId = userId;
    }

    public void OnLoadData(string json)
    {
        if (json != null)
        {
            playerLocalData = JsonUtility.FromJson<PlayerInfo>(json);
        }

        Debug.Log(playerLocalData.activeGames);

        playerLocalData ??= new PlayerInfo();
        playerLocalData.activeGames ??= new List<string>();

        SavePlayerLocalData();

        SceneController.Instance.LoadScene("MainMenu");
    }

    public void SavePlayerLocalData()
    {
        userId ??= FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        SaveAndLoadManager.Instance.SaveData("users/" + userId, JsonUtility.ToJson(playerLocalData));
    }

    public void LoadUserGameData(GameInfo gameInfo)
    {
        userId ??= FirebaseAuth.DefaultInstance.CurrentUser.UserId;

        if (gameInfo.players[0].userId.Equals(userId))
        {
            userGameData = gameInfo.players[0];
        }
        else if (gameInfo.players[1].userId.Equals(userId))
        {
            userGameData = gameInfo.players[1];
        }
    }

    public void SaveGameData()
    {
        SaveAndLoadManager.Instance.SaveData("games/" + gameData.gameId, JsonUtility.ToJson(gameData));
    }

    public void SaveUserGameData()
    {
        if (GameData.Instance.gameData.players[0].userId == GameData.Instance.userGameData.userId)
        {
            GameData.Instance.gameData.players[0] = GameData.Instance.userGameData;
        }
        else if (GameData.Instance.gameData.players[1].userId == GameData.Instance.userGameData.userId)
        {
            GameData.Instance.gameData.players[1] = GameData.Instance.userGameData;
        }
    }

}