using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementVelocity;

    [SerializeField] JoystickUI joystickUI;
    void Start()
    {
        joystickUI.OnMove += PlayerMovement_OnMove;
    }

    private void PlayerMovement_OnMove(Vector3 obj)
    {
        print($"x: {obj.x}, y: {obj.z}");
        rb.velocity = obj * movementVelocity;
    }


    // Update is called once per frame
    void Update()
    {


    }


}
