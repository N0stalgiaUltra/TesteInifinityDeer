using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour, ICollider
{

    public void GetHit()
    {
        DeactivateBullet();
    }

    private void OnBecameInvisible() => DeactivateBullet();


    private void DeactivateBullet()
    {
        this.gameObject.SetActive(false);
        BulletPooling.instance.ReplenishQueue(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        print($"name{other.gameObject.name}, tag: {other.gameObject.tag}");
        GetHit();
    }

}
