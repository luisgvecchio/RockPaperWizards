using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthManagerTests
{
    private const int startHealth = 100;
    HealthManager manager;

    [SetUp]
    public void SetUp()
    {
        manager = new GameObject("Health Manager for testing").AddComponent<HealthManager>();
        manager.health = startHealth;
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(manager.gameObject);
    }

    [Test]
    public void StartsWithFullHealth()
    {
        Assert.AreEqual(100, manager.health);
    }

    [Test]
    public void CanTakeDamage()
    {
        int damage = 1;
        manager.TakeDamage(damage);
        Assert.AreEqual(startHealth - damage, manager.health);
    }


    [Test]
    public void TakingNegativeDamageStillHurts()
    {
        int damage = 1;
        manager.TakeDamage(-damage);
        Assert.AreEqual(startHealth - damage, manager.health);
    }

    [Test]
    public void DontTakeDamageInGodMode()
    {
        int damage = 1;
        manager.SetGodMode(true);
        manager.TakeDamage(damage);
        Assert.AreEqual(startHealth, manager.health);
    }

    [Test]
    public void ExitingGodModeAllowUsToDealDamage()
    {
        int damage = 1;
        manager.SetGodMode(true);
        manager.SetGodMode(false);
        manager.TakeDamage(damage);
        Assert.AreEqual(startHealth - damage, manager.health);
    }
}
