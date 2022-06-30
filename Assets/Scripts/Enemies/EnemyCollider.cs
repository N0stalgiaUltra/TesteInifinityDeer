using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : EnemyHealth, ICollider
{

    private BulletLogic bullet;
    private string colliderTag;
    public void GetHit()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        colliderTag = other.tag;   
    }

}
