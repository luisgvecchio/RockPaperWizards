using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UndeadHealthTests
{
    UndeadHealthManager manager;
    const int startHealth = 100;

    [SetUp]
    public void SetUp()
    {
        manager = new GameObject("undead health testing").AddComponent<UndeadHealthManager>();
        manager.health = startHealth;
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(manager.gameObject);
    }

    [Test]
    public void DamageHealsInstead()
    {
        int damageAmount = 5;
        manager.TakeDamage(damageAmount);
        Assert.AreEqual(startHealth + damageAmount, manager.health);
    }

    [Test]
    public void NegativeDamageStillHealsInstead()
    {
        int damageAmount = 5;
        manager.TakeDamage(-damageAmount);
        Assert.AreEqual(startHealth + damageAmount, manager.health);
    }
}
