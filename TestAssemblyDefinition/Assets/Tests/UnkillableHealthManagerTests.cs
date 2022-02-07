using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UnkillableHealthManagerTests
{
    UnbeatableUndeadHealthManager manager;
    const int startHealth = 100;
    [SetUp]
    public void SetUp()
    {
        manager = new GameObject().AddComponent<UnbeatableUndeadHealthManager>();
        manager.health = 100;
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(manager.gameObject);
    }

    [Test]
    public void DoesntTakeAnyDamage()
    {
        manager.TakeDamage(50);
        Assert.AreEqual(startHealth, manager.health);
    }
}
