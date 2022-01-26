using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonListCreator : MonoBehaviour
{
    public GameObject buttonTemplate, panel;
   
    public ProfileListManager profiles;

    private void Start()
    {
        UpdateButtonList();
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
        foreach (var profile in profiles.profilesList.Profiles)
        {
            Debug.Log(profile);
            Instantiate(buttonTemplate, panel.transform);
            var text = buttonTemplate.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            text.text = profile;
        }
    }
}
