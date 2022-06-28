using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    
    [SerializeField] private BulletLogic bulletPrefab;

    [SerializeField] private Queue<GameObject> bulletQueue = new Queue<GameObject>(35);
    int capacity = 35;
    //[SerializeField] private List<Bullet> bulletList = new List<Bullet>(35);
    void Awake()
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject aux = Instantiate(bulletPrefab.gameObject);
            aux.SetActive(false);
            bulletQueue.Enqueue(aux);
        }
    }

    public GameObject BulletSpawn()
    {
        if (bulletQueue.Count != 0)
        {
            GameObject aux = bulletQueue.Dequeue();
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
            bulletObject.SetActive(false);
            bulletQueue.Enqueue(bulletObject);
        }
        else
            return ;
    }
}
