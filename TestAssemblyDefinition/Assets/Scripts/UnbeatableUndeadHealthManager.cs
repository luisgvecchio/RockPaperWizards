using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbeatableUndeadHealthManager : UndeadHealthManager
{
    protected override bool IsAbleToTakeDamage()
    {
        return false;
    }
}
