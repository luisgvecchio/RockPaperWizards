using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonListCreator : MonoBehaviour
{
    public GameObject buttonTemplate, panel;
   
    public ProfileListManager profileManager;

    private void Start()
    {
        profileManager.OnLoad += UpdateButtonList;
        profileManager.OnSave += UpdateButtonList;
    }

    public void EraseButtonList()
    {
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void UpdateButtonList()
    {
        EraseButtonList();

        foreach (var profile in profileManager.profilesList.Profiles)
        {
            Instantiate(buttonTemplate, panel.transform);
            var text = buttonTemplate.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            text.text = profile;
        }
    }
}
