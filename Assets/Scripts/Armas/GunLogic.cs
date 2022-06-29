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
    private bool canShoot;
    void Start()
    {
        nextFire = 0f;
        ammo = gunData.ammo;   
    }
    private void Update()
    {
        if (Time.time > nextFire)
        {
            canShoot = true;
            nextFire = Time.time + gunData.fireRate;
        }
    }
    /// <summary>
    /// Usado para fazer o player atirar
    /// </summary>
    public void Shoot() {

        if (ammo > 0 && canShoot)
        {
            BulletPooling.instance.BulletSpawn(bulletSpawn);
            muzzleFire.Play();
            ammo--;
            canShoot = false;
        }
        else if (ammo <= 0)
            StartCoroutine(Reload());

    }

    /// <summary>
    /// Usado para recarregar a arma do player.
    /// </summary>
    /// <returns>Espera o tempo de reload e retorna com o numero de munições.</returns>
    IEnumerator Reload()
    {
        print("Recarregando");
        yield return new WaitForSeconds(gunData.reloadTime);
        ammo = gunData.ammo;
        print("parou de recarregar");
    }
}
