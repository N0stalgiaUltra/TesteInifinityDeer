using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    [SerializeField] private GunLogic playerGun;
    [SerializeField] private Transform playerArm;
    //[SerializeField] private JoystickUI joystickUI;

    [SerializeField] bool canPick;
    [SerializeField] private GameObject aux;
    private void Start()
    {
        JoystickUI.playerShooted += PlayerShoot;
        JoystickUI.playerPicked += PickUpGun;
    }

    private void PlayerShoot()
    {
        if(playerGun != null)
        {
            playerGun.Shoot();
        }

    }
    private void FixedUpdate()
    {
        if (playerGun != null)
        {
            playerGun.transform.position = playerArm.position;
            playerGun.transform.rotation = playerArm.rotation;
        }
    }
    private void PickUpGun()
    {
        if (canPick)
        {
            playerGun = aux.GetComponent<GunLogic>();

            playerGun.transform.position = playerArm.position;
            playerGun.transform.rotation = playerArm.rotation;
            playerGun.transform.parent = playerArm;
            aux = null;
            canPick = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gun") && playerGun == null)
        {
            canPick = true;
            aux = other.gameObject;
        }
    }
}
