using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;

    
    public void Move(bool value)
    {
        if (value)
            playerAnim.SetInteger("Move", 1);
        else
            playerAnim.SetInteger("Move", 0);
    }
    public void Hurt()
    {
        playerAnim.SetTrigger("Hurt");
    }
    public void ShootAnim()
    {
        playerAnim.SetTrigger("Shoot");
        //playerAnim.SetBool("Shoot", true);
    }
    public void Die()
    {
        playerAnim.SetTrigger("Die");
    }
}
