using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ProfileListManager : MonoBehaviour
{
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

    public void UpdateProfileList()
    {
        ProfilesSaveData profilesSave = new ProfilesSaveData();

        profilesSave.Profiles = profilesList.Profiles;

        string jsonString = JsonUtility.ToJson(profilesSave);
        PlayerPrefs.SetString("SavedProfilesList", jsonString);
    }
    public void LoadProfileList()
    {
        string jsonString = PlayerPrefs.GetString("SavedProfilesList");

        profilesList = JsonUtility.FromJson<ProfilesSaveData>(jsonString);
    }

    public void EraseAllListElements()
    {
        profilesList.Profiles.Clear();
    }

}
