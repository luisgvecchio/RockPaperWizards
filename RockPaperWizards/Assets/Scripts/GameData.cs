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
        SaveAndLoadManager.Instance.LoadData("users/" + userId, OnLoadData);
    }

    public void OnLoadData(string json)
    {
        Debug.Log(json);

        if (json != null)
        {
            playerLocalData = JsonUtility.FromJson<PlayerInfo>(json);
        }

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

    public void SaveUserGameData()
    {
        userId ??= FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        SaveAndLoadManager.Instance.SaveData("users/" + userId, JsonUtility.ToJson(userGameData));
    }

    public void SaveGameData()
    {
        SaveAndLoadManager.Instance.SaveData("games/" + gameData.gameId, JsonUtility.ToJson(gameData));
    }
}
