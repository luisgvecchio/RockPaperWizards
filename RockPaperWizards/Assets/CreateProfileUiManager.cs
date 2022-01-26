using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateProfileUiManager : MonoBehaviour
{
    public GameObject inputFieldNewProfile, saveNewProfileButton;

    public void OpenCreateProfileUI()
    {
        inputFieldNewProfile.SetActive(true);
        saveNewProfileButton.SetActive(true);
    }
    public void CloseCreateProfileUI()
    {
        inputFieldNewProfile.SetActive(false);
        saveNewProfileButton.SetActive(false);
    }
}
