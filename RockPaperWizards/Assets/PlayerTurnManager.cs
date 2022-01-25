using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
    public bool myTurn;

    public void StartTurn()
    {
        myTurn = true;
    }

    public void EndTrun()
    {
        myTurn = false;
    }
}
