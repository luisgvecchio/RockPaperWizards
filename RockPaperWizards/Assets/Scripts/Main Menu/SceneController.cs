using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController _instance;
    public static SceneController Instance { get { return _instance; } }
    // Start is called before the first frame update

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
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    internal void StartGame(GameInfo gameInfo)
    {
        GameData.Instance.gameData = gameInfo;
        LoadScene("Game");
    }
}
