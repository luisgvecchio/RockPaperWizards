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


public class ProfileListManager : MonoBehaviour
{
    string jsonString;


    public TMP_InputField inputFieldP1, inputFieldP2;


    //public void AddProfileP1()
    //{
    //    profilesList.Profiles.Add(inputFieldP1.text);
    //    UpdateProfileList();
    //}
    //public void AddProfileP2()
    //{
    //    profilesList.Profiles.Add(inputFieldP2.text);
    //    UpdateProfileList();
    //}

    //// This method runs the OnSave event
    //public void UpdateProfileList()
    //{
    //    ProfilesSaveData profilesSave = new ProfilesSaveData();
    //    profilesSave.Profiles = profilesList.Profiles;

    //    jsonString = JsonUtility.ToJson(profilesSave);
    //    PlayerPrefs.SetString("SavedProfilesList", jsonString);

    //    SaveToFirebase(jsonString);

    //    OnSave?.Invoke();
    //}
    //public void SaveToFirebase(string data)
    //{
    //    var db = FirebaseDatabase.DefaultInstance;
    //    var userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

    //    db.RootReference.Child("users").Child(userId).SetRawJsonValueAsync(data);
    //}

    //public void LoadFromFirebase()
    //{
    //    var db = FirebaseDatabase.DefaultInstance;
    //    var userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

    //    db.RootReference.Child("users").Child(userId).GetValueAsync().ContinueWithOnMainThread(task =>
    //    {
    //        if (task.Exception != null)
    //        {
    //            Debug.LogError(task.Exception);
    //        }

    //        DataSnapshot snap = task.Result;

    //        LoadProfileList(snap.GetRawJsonValue());

    //        Debug.Log("LoadFromFirebase");
    //    });
    //}

    // This method runs the OnLoad event
    //public void LoadProfileList(string loadData)
    //{
    //    profilesList = JsonUtility.FromJson<ProfilesSaveData>(loadData);

    //    OnLoad?.Invoke();
    //}

    //public void EraseAllListElements()
    //{
    //    profilesList.Profiles.Clear();
    //}



}
