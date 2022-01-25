using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfMatchManager : MonoBehaviour
{
    public PlayerLifeCounter player1, player2;

    void CheckIfEndOfMatch()
    {
        if (player1.lives == 0 || player2.lives == 0)
        {
            //Method/s for EndOfMatch Display
        }
    }
}
