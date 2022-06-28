using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
        BulletPooling.instance.ReplenishQueue(this.gameObject);
    }
}
