using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private EnemyData enemyData;

    [SerializeField] private int enemyHealth;
    public int health => enemyHealth;
    private EnemySpawner enemySpawner;
    private GameObject enemyParent;


    private void Start()
    {
        enemyHealth = enemyData.health;
        enemyParent = this.gameObject.transform.parent.gameObject;
        enemySpawner = GetComponentInParent<EnemySpawner>();
    }
    private void Update()
    {
        if (enemyHealth <= 0)
        {
            OnDeath();
        }

        if (Input.anyKeyDown)
            Damage(50);
    }
    public void Damage(int value)
    {
        if (this.enemyHealth > 0)
        {
            this.enemyHealth -= value;
            Debug.Log($"Inimigo recebeu: {value} de dano! HP restante {enemyHealth}");
        }

    }

    private void OnDeath()
    {
        enemySpawner.DeactivateEnemy(enemyParent);
        enemyHealth = enemyData.health;
    }

}
