using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementVelocity;

    [SerializeField] private Animator playerAnim;

    Vector3 movement;
    [SerializeField] float rotationSpeed;
    void Start()
    {
        InputManager.OnMove += Move;
    }

    private void Move(Vector3 movementInput)
    {
        movement = movementInput;
        if(Mathf.Abs(movementInput.x) > Mathf.Epsilon || Mathf.Abs(movementInput.z) > Mathf.Epsilon)
        {
            playerAnim.SetInteger("Move", 1);
        }
        else
            playerAnim.SetInteger("Move", 0);

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
