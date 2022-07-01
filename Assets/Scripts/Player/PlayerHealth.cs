using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private PlayerAnimation playerAnimation;
    private int playerHealth;
    public int health => playerHealth;

    public void Damage(int value)
    {
        if (playerHealth > 0)
            playerHealth -= value;
        //else
        //    Die();
        
        playerAnimation.Hurt();
        print($"Player perdeu {value} de HP");
    }
    public void Die()
    {
        playerAnimation.Die();
    }
    public void Heal(int value)
    {
        if (playerHealth > 0)
            playerHealth += value;
    }
}
