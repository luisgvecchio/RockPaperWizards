using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonListCreator : MonoBehaviour
{
    public GameObject buttonTemplate, panel;

    int maxNumberButtons = 5;

    private void Start()
    {
        UpdateGameList();
    }
    private void UpdateGameList()
    {
        PlayerInfo temporalPlayerInfo = GameData.Instance.playerLocalData;

        EraseButtons();

        //create new list, load each of the users active games
        if (GameData.Instance.playerLocalData.activeGames != null)
        {
            foreach (string gameID in GameData.Instance.playerLocalData.activeGames)
            {
                SaveAndLoadManager.Instance.LoadData("games/" + gameID, LoadGameInfo);
            }
        }
        //We have to few games, create a create game button
        if (GameData.Instance.playerLocalData.activeGames.Count < maxNumberButtons)
        {
            CreateButton("New Game", () => SaveAndLoadManager.Instance.LoadData("games/", NewGame));
        }
    }

    private void EraseButtons()
    {
        foreach (Transform child in panel.transform)
            Destroy(child.gameObject);
    }

    private void NewGame(List<string> data)
    {
        List<GameInfo> loadedGames = new List<GameInfo>();

        foreach (var game in data)
        {
            loadedGames.Add(JsonUtility.FromJson<GameInfo>(game));
        }

        foreach (var game in loadedGames)
        {
            if (!GameData.Instance.playerLocalData.activeGames.Contains(game.gameId) && game.openPlayerSlots > 0)
            {
                JoinGame(game);
                return;
            }
        }

        CreateGame();
    }

    private void CreateButton(string buttonText, UnityAction onClickAction)
    {
        var newButton = Instantiate(buttonTemplate, panel.transform).GetComponent<Button>();
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
        newButton.onClick.AddListener(onClickAction);
        newButton.onClick.AddListener(UpdateGameList);
    }

    public void LoadGameInfo(string json)
    {
        if (json == "" || json == null)
        {
            return;
        }

        var gameInfo = JsonUtility.FromJson<GameInfo>(json);

        var newButton = Instantiate(buttonTemplate, panel.transform).GetComponent<Button>();
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = gameInfo.gameName;

        newButton.onClick.AddListener(() => SceneController.Instance.StartGame(gameInfo));
        newButton.onClick.AddListener(() => GameData.Instance.LoadUserGameData(gameInfo));
    }

    public void CreateGame()
    {
        //Create a new game and start filling out the info.
        var newGameInfo = new GameInfo();

        newGameInfo.gameName = GameData.Instance.userGameData.name + "'s game";

        SetDefaultCreatePlayerValues();
        //Add the user as the first player
        newGameInfo.players = new List<PlayerInGameData>();
        newGameInfo.players.Add(GameData.Instance.userGameData);

        //Substract OpenPlayerSlots
        newGameInfo.openPlayerSlots--;

        //get a unique ID for the game
        string key = SaveAndLoadManager.Instance.GetKey("games/");
        newGameInfo.gameId = key;

        //convert to json
        string data = JsonUtility.ToJson(newGameInfo);

        //Save our new game
        string path = "games/" + key;
        SaveAndLoadManager.Instance.SaveData(path, data);

        //add the key to our active games
        GameCreated(key, newGameInfo);
    }

    public void GameCreated(string gameKey, GameInfo gameInfo)
    {
        //If we dont have any active games, create the list.
        GameData.Instance.playerLocalData.activeGames ??= new List<string>();
        GameData.Instance.playerLocalData.activeGames.Add(gameKey);

        //save our user with our new game and all local data

        GameData.Instance.SavePlayerLocalData();
        //GameData.Instance.SaveUserGameData();


        //Start the game
        SceneController.Instance.StartGame(gameInfo);
    }

    private void SetDefaultCreatePlayerValues()
    {
        GameData.Instance.userGameData.playerNumber = 1;
        GameData.Instance.userGameData.lives = 5;
    }
    private void SetDefaultJoinPlayerValues()
    {
        GameData.Instance.userGameData.playerNumber = 2;
        GameData.Instance.userGameData.lives = 5;
    }

    public void JoinGame(GameInfo gameInfo)
    {
        GameData.Instance.playerLocalData.activeGames.Add(gameInfo.gameId);

        GameData.Instance.SavePlayerLocalData();

        SetDefaultJoinPlayerValues();

        gameInfo.players.Add(GameData.Instance.userGameData);

        //Update new game name
        gameInfo.gameName = gameInfo.players[0].name + " vs " + GameData.Instance.userGameData.name;
        
        gameInfo.openPlayerSlots--;

        string jsonString = JsonUtility.ToJson(gameInfo);

        //Update the game
        SaveAndLoadManager.Instance.SaveData("games/" + gameInfo.gameId, jsonString);

        //Start the game
        SceneController.Instance.StartGame(gameInfo);
    }

}
