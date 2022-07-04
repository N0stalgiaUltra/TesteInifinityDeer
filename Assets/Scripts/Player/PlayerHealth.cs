using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    private PlayerAnimation playerAnimation;
    private int playerHealth;
    private readonly int totalHealth = 200;
    public int health => playerHealth;

    public delegate void OnHealthChange();
    public event OnHealthChange healthChanged;
    private void Awake()
    {
        playerHealth = totalHealth;
        playerAnimation = GetComponent<PlayerAnimation>();
    }
    private void Update()
    {
        if (playerHealth <= 0)
            Die();
    }
    public void Damage(int value)
    {
        if (playerHealth > 0)
            playerHealth -= value;
        else
            Die();

        playerAnimation.Hurt();
        healthChanged?.Invoke();
        print($"Player perdeu {value} de HP");
    }
    public void Die()
    {
        playerAnimation.Die();
        GameManager.instance.GameOver(false);
        playerHealth = totalHealth;
    }
    public void Heal(int value)
    {
        if (playerHealth > 0)
            playerHealth += value;
    }
    public int HealthPlayer { get => playerHealth; }
    public int TotalHealt { get => totalHealth; }
}
