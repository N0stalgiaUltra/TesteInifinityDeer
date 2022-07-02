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
            OnDeath();
    }
    public void Damage(int value)
    {
        if (this.enemyHealth > 0)
        {
            this.enemyHealth -= value;

        }

    }

    private void OnDeath()
    {
        enemySpawner.DeactivateEnemy(enemyParent);
        enemyHealth = enemyData.health;
    }

}
