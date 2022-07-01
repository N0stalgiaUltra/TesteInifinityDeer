using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : EnemyHealth, ICollider
{

    private string colliderTag;
    private int damage;

    public void GetHit()
    {
        Damage(damage);
    }


    private void OnTriggerEnter(Collider other)
    {
        colliderTag = other.tag;

        if (colliderTag.Equals("Bullet"))
            damage = other.GetComponent<BulletLogic>().damage;
        
        GetHit();
    }

}
