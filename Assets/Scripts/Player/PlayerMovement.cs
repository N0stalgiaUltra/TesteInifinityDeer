using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script usado para movimentar o player
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementVelocity;

    [SerializeField] private PlayerAnimation playerAnim;

    [SerializeField] private PhotonView view;
    Vector3 movement;
    [SerializeField] float rotationSpeed;
    void Start()
    {
        InputManager.OnMove += Move;
    }

    /// <summary>
    /// Metodo usado para movimentar o player
    /// </summary>
    /// <param name="movementInput">vetor de 3 dimensões recebidos do input, usados para movimentar o player</param>
    private void Move(Vector3 movementInput)
    {
        if (view.IsMine)
        {
            movement = movementInput;
            if (Mathf.Abs(movementInput.x) > Mathf.Epsilon || Mathf.Abs(movementInput.z) > Mathf.Epsilon)
            {
                playerAnim.Move(true);
            }
            else
                playerAnim.Move(false);

            if (movement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        
    }

    void FixedUpdate()
    {
        if(view.IsMine)
            rb.velocity = movement * movementVelocity;
    }

    private void OnDisable()
    {
        InputManager.OnMove -= Move;
    }
}
