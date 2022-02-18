using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterNameManager : MonoBehaviour
{
    public TMP_InputField nameField;

    public void SaveUserName()
    {
        GameData.Instance.playerLocalData.name = nameField.text;
        GameData.Instance.userGameData.name = GameData.Instance.playerLocalData.name;
        GameData.Instance.SavePlayerLocalData();
    }
}
