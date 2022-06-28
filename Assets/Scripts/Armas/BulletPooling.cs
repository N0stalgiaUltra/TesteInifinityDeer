using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    
    [SerializeField] private BulletLogic bulletPrefab;

    [SerializeField] private Queue<BulletLogic> bulletQueue = new Queue<BulletLogic>(35);
    int capacity = 35;

    public static BulletPooling instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
            instance = this;

        for (int i = 0; i < capacity; i++)
        {
            BulletLogic aux = Instantiate(bulletPrefab, this.transform);
            aux.gameObject.SetActive(false);
            bulletQueue.Enqueue(aux);
        }
    }

    public GameObject BulletSpawn(Transform bulletSpawn)
    {
        if (bulletQueue.Count != 0)
        {
            GameObject aux = bulletQueue.Dequeue().gameObject;
            aux.transform.position = bulletSpawn.position;
            aux.SetActive(true);
            return aux;
        }
        else
        {
            Debug.LogError("Fila de objetos vazia");
            return null;
        }

    }

    public void ReplenishQueue(GameObject bulletObject)
    {
        if (bulletQueue.Count != capacity)
        {
            BulletLogic aux = bulletObject.GetComponent<BulletLogic>();
            bulletObject.SetActive(false);
            bulletQueue.Enqueue(aux);
        }
        else
            return ;
    }
}
