using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    [SerializeField] private Gun gunData;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private ParticleSystem muzzleFire;
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
        
        
           
    }

    public void Shoot() {

        if (ammo > 0 && Time.time > nextFire)
        {
            nextFire = Time.time + gunData.fireRate;
            GameObject a = BulletPooling.instance.BulletSpawn(bulletSpawn);
            muzzleFire.Play();
            ammo--;
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
