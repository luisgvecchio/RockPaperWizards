using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LevelTesting
{
    Level lvl;

    [SetUp]
    public void SetUp()
    {
        lvl = new GameObject().AddComponent<Level>();
        lvl.Initialize();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(lvl.gameObject);
    }

    [Test]
    public void StartsAtLevelOne()
    {
        Assert.AreEqual(1, lvl.GetCurrentLevel());
    }

    [Test]
    [TestCase(1, 2)]
    [TestCase(2, 3)]
    [TestCase(100, 101)]
    [TestCase(0, 1)]
    public void CanLevelUp(int timesToLevelUp, int assumedLevel)
    {
        for (int i = 0; i < timesToLevelUp; i++)
        {
            lvl.LevelUp();
        }
        Assert.AreEqual(assumedLevel, lvl.GetCurrentLevel());
    }

    [Test]
    public void CanAddExperience()
    {
        lvl.AddExp(1);
        Assert.AreEqual(1, lvl.GetCurrentExp());
    }

    [Test]
    public void LevelingUpZeroesOutExp()
    {
        lvl.AddExp(1);
        lvl.LevelUp();
        Assert.AreEqual(0, lvl.GetCurrentExp());
    }

    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void CanLevelUpFromExp(int timesToLevelUp)
    {
        for (int i = 0; i < timesToLevelUp; i++)
        {
            lvl.AddExp(lvl.GetExpRequiredToLevelUp());
        }

        Assert.AreEqual(1 + timesToLevelUp, lvl.GetCurrentLevel());
    }

    [Test]
    public void smallAmountOfExperienceDoesntCauseALevel()
    {
        lvl.AddExp(1);
        Assert.AreEqual(1, lvl.GetCurrentLevel());
    }

    [Test]
    public void CanGetRequiredExp()
    {
        Assert.AreEqual(100, lvl.GetExpRequiredToLevelUp());
    }
}
