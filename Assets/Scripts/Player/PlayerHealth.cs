using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    private int playerHealth;
    public int health => playerHealth;

    public void Damage(int value)
    {
        if (playerHealth > 0)
            playerHealth -= value;
        print($"Player perdeu {value} de HP");
    }

    public void Heal(int value)
    {
        if (playerHealth > 0)
            playerHealth += value;
    }
}
