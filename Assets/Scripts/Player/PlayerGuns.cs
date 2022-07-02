using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuns : PickUpItems
{
    [SerializeField] private GunLogic playerGun;
    [SerializeField] private Transform playerArm;
    [SerializeField] private PlayerAnimation playerAnim;

    private void Start()
    {
        InputManager.playerShooted += ()=> playerAnim.ShootAnim(); 
        InputManager.playerPicked += PickUpGun;
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
    /// Usado para fazer o player pegar uma arma no chão ou substituir a arma atual (Chamado ao clicar no botão de "PICK")
    /// </summary>
    private void PickUpGun()
    {
        if (canPick)
        {
            if (playerGun != null)
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
            canPick = false;
        }
        else return;
    }

  
}
