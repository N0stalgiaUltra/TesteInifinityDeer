using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    [SerializeField] private Gun gunData;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Transform gunSpawn;

    public int ammo;
    
    private float nextFire;
    void Start()
    {
        nextFire = 0f;
        ammo = gunData.ammo;   
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + gunData.fireRate;
            Shoot();
        }   
    }

    public void Shoot() {

        if (ammo > 0)
        {
            ammo--;
            print("Atirando");
        }
        else
            StartCoroutine(Reload());
        
    }

    IEnumerator Reload()
    {
        print("Recarregando");
        yield return new WaitForSeconds(gunData.reloadTime);
        ammo = gunData.ammo;
        print("parou de recarregar");
    }
}
