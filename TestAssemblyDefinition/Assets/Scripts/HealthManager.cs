using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    protected bool isDead;
    protected bool isInvulnerable;
    protected bool godMode;
    public int health;

    public virtual void TakeDamage(int amount)
    {
       
        if (IsAbleToTakeDamage() == false) return;

        amount = Mathf.Abs(amount);

        health -= amount;
    }

    protected virtual bool IsAbleToTakeDamage()
    {
        if (isDead) return false;
        if (isInvulnerable) return false;
        if (godMode) return false;
        return true;
    }

    public void SetGodMode(bool tf)
    {
        godMode = tf;
    }

    public int GetHealth() => health;
}
