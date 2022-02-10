using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using System.Text;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Extensions;

public delegate void LoadProfileList();
public delegate void UpdateProfileList();

[System.Serializable]
public class ProfilesSaveData
{
    public List<string> Profiles = new List<string>();
}

public class ProfileListManager : MonoBehaviour
{
    string jsonString;

    public TMP_InputField inputFieldP1, inputFieldP2;
    public ProfilesSaveData profilesList = new ProfilesSaveData();

    public event LoadProfileList OnLoad;
    public event UpdateProfileList OnSave;

    public void AddProfileP1()
    {
        profilesList.Profiles.Add(inputFieldP1.text);
        UpdateProfileList();
    }
    public void AddProfileP2()
    {
        profilesList.Profiles.Add(inputFieldP2.text);
        UpdateProfileList();
    }


    //It is saving on, PlayerPrefs, ProfilesData.json and Uploading it to Firebase
    public void UpdateProfileList()
    {
        ProfilesSaveData profilesSave = new ProfilesSaveData();

        profilesSave.Profiles = profilesList.Profiles;

        jsonString = JsonUtility.ToJson(profilesSave);
        PlayerPrefs.SetString("SavedProfilesList", jsonString);

        SaveToFirebase(jsonString);

        OnSave?.Invoke();
    }

    //It only loads from ProfileData.json
    public void LoadProfileList(string loadData)
    {
        profilesList = JsonUtility.FromJson<ProfilesSaveData>(loadData);

        OnLoad?.Invoke();
    }

    public void LoadFromFirebase()
    {
        var db = FirebaseDatabase.DefaultInstance;
        var userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

        db.RootReference.Child("users").Child(userId).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogError(task.Exception);
            }

            DataSnapshot snap = task.Result;

            LoadProfileList(snap.GetRawJsonValue());
                        
            Debug.Log("LoadFromFirebase");
        });
    }

    public void EraseAllListElements()
    {
        profilesList.Profiles.Clear();
    }

    public void SaveToFirebase(string data)
    {
        var db = FirebaseDatabase.DefaultInstance;
        var userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

        db.RootReference.Child("users").Child(userId).SetRawJsonValueAsync(data);
    }
    

}
