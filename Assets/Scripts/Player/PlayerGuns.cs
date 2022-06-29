using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : MonoBehaviour
{
    [SerializeField] private GunLogic playerGun;
    [SerializeField] private Transform playerArm;

    bool canPick;
    private GameObject aux;
    private void Start()
    {
        JoystickUI.playerShooted += PlayerShoot;
        JoystickUI.playerPicked += PickUpGun;
    }
    private void FixedUpdate()
    {
        if (playerGun != null)
        {
            playerGun.transform.position = playerArm.position;
            playerGun.transform.rotation = playerArm.rotation;
        }
    }

    /// <summary>
    /// Ação para fazer o player atirar.
    /// </summary>
    private void PlayerShoot()
    {
        //OBS: esse trecho pode parecer redundante, mas ele apenas verifica se o player tem uma arma para atirar, se não, não faz nada.
        if(playerGun != null)
        {
            playerGun.Shoot();
        }

    }

    /// <summary>
    /// Usado para fazer o player pegar uma arma no chão ou substituir a arma atual
    /// </summary>
    private void PickUpGun()
    {
        if(playerGun != null)
        {
            playerGun.transform.SetParent(null);
            Destroy(playerGun.gameObject);
            //playerGun = null;
        }

        playerGun = aux.GetComponent<GunLogic>();

        playerGun.transform.position = playerArm.position;
        playerGun.transform.rotation = playerArm.rotation;
        playerGun.transform.parent = playerArm;
            
        aux = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            aux = other.gameObject;
        }
    }
}
