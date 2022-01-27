using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveName : MonoBehaviour
{
    string nameP1, nameP2;

    void Start()
    {
        if (gameObject.CompareTag("P1Name"))
        {
            nameP1 = GetComponentInChildren<TextMeshProUGUI>().text;
        }
        else if (gameObject.CompareTag("P2Name"))
        {
            nameP2 = GetComponentInChildren<TextMeshProUGUI>().text;
        }
    }
    public void SavePlayer1Name()
    {
        PlayerPrefs.SetString("Player1Name", nameP1);
    }
    public void SavePlayer2Name()
    {
        PlayerPrefs.SetString("Player2Name", nameP2);
    }
}
