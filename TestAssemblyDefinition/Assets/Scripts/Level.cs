using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * S = Single Responsibility Principle 
 * O = Open/Close Principle
 * L = Litchov Substituation Principle 
 * I = Interface Segregation Principle 
 * D = Dependency Inversion Principle
 * 
 * 
 * 
 * 
 */

// The Code is OPEN for extension but CLOSED for modification


























// TDD = LEAST code necessary to succeed.
// TDD = test FIRST!
// TDD = RED Then GREEN

public class Level : MonoBehaviour
{
    private int currentLevel;
    private int exp;

    public Dictionary<int, int> experiencePerLevel;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        currentLevel = 1;
        experiencePerLevel = new Dictionary<int, int>();
        experiencePerLevel.Add(1, 0);
        experiencePerLevel.Add(2, 100);
        experiencePerLevel.Add(3, 500);
        experiencePerLevel.Add(4, 2000);
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void LevelUp()
    {
        exp = 0;
        currentLevel++;
    }

    public void AddExp(int v)
    {
        exp += v;
        if (exp >= experiencePerLevel[currentLevel + 1])
        {
            LevelUp();
        }
    }

    public int GetCurrentExp()
    {
        return exp;
    }

    public int GetExpRequiredToLevelUp()
    {
        return experiencePerLevel[currentLevel + 1];
    }
}
