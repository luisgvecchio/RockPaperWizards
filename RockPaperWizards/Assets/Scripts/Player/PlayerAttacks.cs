using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Attacks
    {
        Fire,
        Water,
        Plant
    }

public class PlayerAttacks : MonoBehaviour
{

    public Attacks chosenattack;

    public void ChoseFire()
    {
        chosenattack = Attacks.Fire;
    }
    public void ChoseWater()
    {
        chosenattack = Attacks.Water;
    }
    public void ChosePlant()
    {
        chosenattack = Attacks.Plant;
    }

}
