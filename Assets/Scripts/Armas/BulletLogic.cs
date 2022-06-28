using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody rbBullet;
    [SerializeField] private float speed;

    void FixedUpdate()
    {
        if(gameObject.activeSelf)
            rbBullet.AddForce(Vector3.forward * speed, ForceMode.Impulse);
    }
}
