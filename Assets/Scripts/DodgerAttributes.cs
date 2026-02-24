using UnityEngine;
using System;

public class DodgerAttributes
{
    private int health;
    private int maxHealth;
    private int currentScore;

    public DodgerAttributes(int initalHP, int initalMaxHP, int initalScore)
    {
        health = initalHP;
        maxHealth = initalMaxHP;
        currentScore = initalScore;
    }

    // Get Methods
    public int getHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getCurrentScore()
    {
        return currentScore;
    }

    // Set Methods
    public void setHealth(int newHealth)
    {
        health = Math.Clamp(newHealth, 0, maxHealth); //ensure Health does not exceed Max Health
    }

    public void setCurrentScore(int newScore)
    {
        currentScore = newScore;
    }


}
