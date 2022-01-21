using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveName : MonoBehaviour
{
    TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.text = PlayerPrefs.GetString("PlayerName");
    }

    // Update is called once per frame
    public void SavePlayerName()
    {
        PlayerPrefs.SetString("PlayerName", inputField.text);
    }
}
