using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    [SerializeField] protected bool canPick;
    protected GameObject aux;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gun"))
        {
            canPick = true;
            aux = other.gameObject;
        }
        else
            canPick = false;
    }
}
