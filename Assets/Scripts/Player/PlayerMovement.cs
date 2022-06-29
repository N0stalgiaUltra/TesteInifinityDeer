using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementVelocity;

    Vector3 movement;
    [SerializeField] float rotationSpeed;
    void Start()
    {
        JoystickUI.OnMove += Move;
    }

    private void Move(Vector3 movementInput)
    {
        movement = movementInput;
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = movement * movementVelocity;


    }


}
