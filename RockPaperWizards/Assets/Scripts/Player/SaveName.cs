using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveName : MonoBehaviour
{
    string namePlayer;

    void Start()
    {
        if (gameObject.CompareTag("P1Name"))
        {
            namePlayer = GetComponentInChildren<TextMeshProUGUI>().text;
        }
        else if (gameObject.CompareTag("P2Name"))
        {
            namePlayer = GetComponentInChildren<TextMeshProUGUI>().text;
        }
    }
    public void SavePlayer1Name()
    {
        PlayerPrefs.SetString("Player1Name", namePlayer);
    }
    public void SavePlayer2Name()
    {
        PlayerPrefs.SetString("Player2Name", namePlayer);
    }
}
