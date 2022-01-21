using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
    public PlayerMovement playerMovement;

    // Update is called once per frame
    public void Save()
    {
       PlayerPrefs.SetFloat("PlayerXPosition", playerMovement.mousePosition.x);
       PlayerPrefs.SetFloat("PlayerYPosition", playerMovement.mousePosition.y);

    }

    public void Load()
    {
        float x = PlayerPrefs.GetFloat("PlayerXPosition");
        float y = PlayerPrefs.GetFloat("PlayerYPosition");

        playerMovement.mousePosition = new Vector3(x, y, 0);
    }
}
