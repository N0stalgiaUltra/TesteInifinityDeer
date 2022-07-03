using System;
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

    public delegate void EnemyDied(GameObject obj);
    public static event EnemyDied enemyDead;
    private void Start()
    {
        enemyHealth = enemyData.health;
        enemyParent = this.gameObject.transform.parent.gameObject;
        print(enemyParent.name);
        enemySpawner = GetComponentInParent<EnemySpawner>();
    }
    private void Update()
    {
        if (enemyHealth <= 0)
        {
            OnDeath();
        }
    }
    public void Damage(int value)
    {
        if (this.enemyHealth > 0)
            this.enemyHealth -= value;
    }

    private void OnDeath()
    {
        if (enemyDead != null)
            enemyDead(this.gameObject);

        enemySpawner.DeactivateEnemy(enemyParent, enemyData);
        this.gameObject.SetActive(false);
        enemyHealth = enemyData.health;
    }

}
