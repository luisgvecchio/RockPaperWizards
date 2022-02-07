using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadHealthManager : HealthManager
{
    public override void TakeDamage(int amount)
    {
        if (IsAbleToTakeDamage() == false) return;

        amount = Mathf.Abs(amount);

        health += amount;

    }

}
