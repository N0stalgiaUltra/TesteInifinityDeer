using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private PlayerAnimation playerAnimation;
    private int playerHealth;
    [SerializeField]protected int totalHealth = 100;
    public int health => playerHealth;

    public delegate void OnHealthChange();
    public event OnHealthChange healthChanged;
    private void Awake()
    {
        playerHealth = totalHealth;
    }
    public void Damage(int value)
    {
        if (playerHealth > 0)
            playerHealth -= value;
        //else
        //    Die();
        
        playerAnimation.Hurt();
        healthChanged?.Invoke();
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
    private void Update()
    {
        if (Input.anyKeyDown)
            Damage(1);
    }

    public int HealthPlayer { get => playerHealth; }
}
