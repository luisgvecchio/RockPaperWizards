using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;


public class SaveAndLoadManager : MonoBehaviour
{
    private static SaveAndLoadManager _instance;
    public static SaveAndLoadManager Instance { get { return _instance; } }

    public delegate void OnLoadedDelegateMultiple(List<string> jsonData);
    public delegate void OnLoadedDelegate(string json);
    public delegate void SaveToFirebase();

    FirebaseDatabase dataBase;

    string jsonString;

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

        dataBase = FirebaseDatabase.DefaultInstance;
    }

    //loads the data at "path" then returns json result to the delegate/callback function
    public void LoadData(string path, OnLoadedDelegate onLoadedDelegate)
    {
        dataBase.RootReference.Child(path).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);

            onLoadedDelegate(task.Result.GetRawJsonValue());
        });
    }

    //This loads multiple data and returns it as a string list with json.
    public void LoadData(string path, OnLoadedDelegateMultiple onLoadedDelegates)
    {
        dataBase.RootReference.Child(path).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            List<string> loadedJson = new List<string>();

            foreach (var item in task.Result.Children)
            {
                loadedJson.Add(item.GetRawJsonValue());
            }

            onLoadedDelegates(loadedJson);
        });
    }

    //Save the data at the given path
    public void SaveData(string path, string jsonData, SaveToFirebase onSave = null)
    {
        dataBase.RootReference.Child(path).SetRawJsonValueAsync(jsonData).ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
                Debug.LogWarning(task.Exception);

            onSave?.Invoke();
        });
    }

    public string GetKey(string path)
    {
        return dataBase.RootReference.Child(path).Push().Key;
    }
}
