using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    [SerializeField] private GunLogic playerGun;
    [SerializeField] private Transform playerArm;
    //[SerializeField] private JoystickUI joystickUI;

    private bool haveGun;

    private void Start()
    {
        JoystickUI.playerShooted += PlayerShoot;
        JoystickUI.playerShooted += PickUpGun;
    }

    private void PlayerShoot()
    {
        if(playerGun != null)
        {
            playerGun.Shoot();
        }

    }

    private void PickUpGun()
    {
        if(playerGun == null)
        {
            print("pega a arma do chao");
        }
    }

}
