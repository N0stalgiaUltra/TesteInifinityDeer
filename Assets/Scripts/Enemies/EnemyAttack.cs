using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private EnemyData enemyData;
    private GameObject playerPrefab;

    public int EnemyDamage { get => enemyData.damage; }
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPrefab = GameManager.instance.ReturnNearestPlayer(this.transform);
    }

    protected virtual void Attack(GameObject player)
    {
        print("base attack");
    }
}
