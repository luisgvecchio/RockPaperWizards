using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPlayerChosenNameController : MonoBehaviour
{
    public TextMeshProUGUI chosenName;

    private void Update()
    {
        if (gameObject.CompareTag("P1Name")) ShowP1Name();
        if (gameObject.CompareTag("P2Name")) ShowP2Name();
    }

    public void ShowP1Name()
    {
        chosenName.text = PlayerPrefs.GetString("Player1Name");
    }
    public void ShowP2Name()
    {
        chosenName.text = PlayerPrefs.GetString("Player2Name"); 
    }

}
