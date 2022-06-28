using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Create Gun")]
public class Gun : ScriptableObject
{
    public int damage;
    public float fireRate;
    public int ammo;
    public int maxAmmo;
    public float reloadTime;
    public bool canHold;
}
