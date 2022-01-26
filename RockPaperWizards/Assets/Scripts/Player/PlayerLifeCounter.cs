using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeCounter : MonoBehaviour
{
    public int lives;
    public List<GameObject> livesArray;

    public void UpdateLivesUI()
    {
        var length = livesArray.Count;

        Debug.Log(length);

        if(lives < length)
        {
            Destroy(livesArray[length - 1]);
            livesArray.RemoveAt(length - 1);
        }
    }


}
