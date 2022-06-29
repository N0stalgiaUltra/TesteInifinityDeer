using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : PlayerHealth, ICollider
{
    int damage;
    
    public void GetHit()
    {
        Damage(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            damage = other.GetComponent<EnemyAttack>().EnemyDamage;
            GetHit();
        }
    }
}
