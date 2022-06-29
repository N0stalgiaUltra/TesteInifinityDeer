using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : EnemyHealth, ICollider
{

    private BulletLogic bullet;
    public void GetHit()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GetHit();
        }
    }

}
