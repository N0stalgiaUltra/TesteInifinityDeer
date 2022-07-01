using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private EnemyData enemyData;

    protected virtual void Attack(GameObject player)
    {
        print(player.name);
        player.GetComponent<PlayerHealth>().Damage(enemyData.damage);
    }
}
