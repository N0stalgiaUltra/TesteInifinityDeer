using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody rbBullet;
    [SerializeField] private float speed;
    public Transform playerTransform;

    void FixedUpdate()
    {
        if(gameObject.activeSelf)
            rbBullet.AddForce(playerTransform.transform.forward * speed, ForceMode.Impulse);
    }
}
