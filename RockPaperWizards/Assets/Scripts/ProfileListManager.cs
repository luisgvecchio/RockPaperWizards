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

public class ProfileListManager : MonoBehaviour
{

    string jsonString;

    [Serializable]
    public class ProfilesSaveData
    {
        public List<string> Profiles = new List<string>();
    }

    public TMP_InputField inputFieldP1, inputFieldP2;
    public ProfilesSaveData profilesList = new ProfilesSaveData();

    public void AddProfileP1()
    {
       profilesList.Profiles.Add(inputFieldP1.text);
        
    }
    public void AddProfileP2()
    {
        profilesList.Profiles.Add(inputFieldP2.text);
    }


    //It is saving on, PlayerPrefs, ProfilesData.json and Uploading it to Firebase
    public void UpdateProfileList()
    {
        ProfilesSaveData profilesSave = new ProfilesSaveData();

        profilesSave.Profiles = profilesList.Profiles;

        jsonString = JsonUtility.ToJson(profilesSave);
        PlayerPrefs.SetString("SavedProfilesList", jsonString);

        SaveToFile("ProfilesData.json", jsonString);
        SaveToFirebase(jsonString);
    }

    //It only loads from ProfileData.json
    public void LoadProfileList(string loadData)
    {
        //string jsonString = PlayerPrefs.GetString("SavedProfilesList");

        profilesList = JsonUtility.FromJson<ProfilesSaveData>(LoadFromFile(loadData));
    }

    public void LoadFromFirebase()
    {
        var db = FirebaseDatabase.DefaultInstance;
        var userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        db.RootReference.Child("users").Child(userId).Child("Profiles").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Exception != null)
            {
                Debug.LogError(task.Exception);
            }

            //here we get the result from our database.
            DataSnapshot snap = task.Result;

            //And send the json data to a function that can update our game.

            LoadProfileList(snap.GetRawJsonValue());
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
        //puts the json data in the "users/userId" part of the database.
        db.RootReference.Child("users").Child(userId).SetRawJsonValueAsync(data);
    }

    public void SaveToFile(string fileName, string jsonString)
    {
        // Open a file in write mode. This will create the file if it's missing.
        // It is assumed that the path already exists.
        using (var stream = File.OpenWrite(fileName))
        {
            // Truncate the file if it exists (we want to overwrite the file)
            stream.SetLength(0);

            // Convert the string into bytes. Assume that the character-encoding is UTF8.
            // Do you not know what encoding you have? Then you have UTF-8
            var bytes = Encoding.UTF8.GetBytes(jsonString);

            // Write the bytes to the hard-drive
            stream.Write(bytes, 0, bytes.Length);

            // The "using" statement will automatically close the stream after we leave
            // the scope - this is VERY important
            Debug.Log("working");
        }
    }
    public string LoadFromFile(string fileName)
    {
        // Open a stream for the supplied file name as a text file
        using (var stream = File.OpenText(fileName))
        {
            // Read the entire file and return the result. This assumes that we've written the
            // file in UTF-8
            return stream.ReadToEnd();
        }
    }

}
