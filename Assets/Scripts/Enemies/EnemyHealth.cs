using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private EnemyData enemyData;

    private int enemyHealth { get => enemyData.health; set => enemyData.health = value; }
    public int health => enemyHealth;

    public void Damage(int value)
    {
        if (this.enemyHealth > 0)
        {
            this.enemyHealth -= value;
            Debug.Log($"Inimigo recebeu: {value} de dano! HP restante {enemyHealth}");
        }
    }

}
