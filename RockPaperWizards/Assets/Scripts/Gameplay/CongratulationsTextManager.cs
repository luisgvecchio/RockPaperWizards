using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CongratulationsTextManager : MonoBehaviour
{
    public TextMeshProUGUI congratulations;

    public void SetCongratulationsMessage(string winner)
    {
        congratulations.text = "Congratulations " + winner + "!!!";
    }
}
