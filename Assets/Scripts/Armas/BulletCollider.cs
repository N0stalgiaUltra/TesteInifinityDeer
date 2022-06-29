using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour, ICollider
{
    [SerializeField] private BulletLogic bulletLogic;
    private EnemyHealth enemy;

    public void GetHit()
    {
        enemy.Damage(bulletLogic.damage);
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
        if (other.CompareTag("Inimigo"))
        {
            enemy = other.GetComponent<EnemyHealth>();
            GetHit();
            print("colidiu");
        }
    }

}
