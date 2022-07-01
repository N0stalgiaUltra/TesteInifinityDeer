using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : PlayerHealth, ICollider
{
    [Serializable]
    public struct Enemy
    {
        public string nameEnemy;
        public EnemyData data;
    }
    [SerializeField] private Enemy[] enemyData = new Enemy[3];

    private string enemyTag;

    public void GetHit()
    {
        foreach(Enemy e in enemyData)
        {
            if (enemyTag.Equals(e.nameEnemy))
            {
                Damage(e.data.damage / 10);
                Debug.Log($"Dano: {e.data.damage}, Inimigo: {e.nameEnemy}");
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        enemyTag = collision.gameObject.tag;
        GetHit();
    }

}
