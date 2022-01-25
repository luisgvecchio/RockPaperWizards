using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveName : MonoBehaviour
{
    public TMP_InputField inputFieldP1, inputFieldP2;
    // Start is called before the first frame update
    void Start()
    {
        inputFieldP1.text = PlayerPrefs.GetString("Player1Name");
        inputFieldP2.text = PlayerPrefs.GetString("Player2Name");
    }

    // Update is called once per frame
    public void SavePlayer1Name()
    {
        PlayerPrefs.SetString("Player1Name", inputFieldP1.text);
    }
    public void SavePlayer2Name()
    {
        PlayerPrefs.SetString("Player2Name", inputFieldP2.text);
    }
}
