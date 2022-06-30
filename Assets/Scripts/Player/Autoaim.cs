using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoaim : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesList = new List<GameObject>();
    [SerializeField] private Transform player;

    [SerializeField] private int count;
    void Start()
    {
        InputManager.playerAimed += AutoAim;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AutoAim()
    {
        if (enemiesList.Count != 0)
        {
            if (count >= enemiesList.Count)
                count = 0;

            player.transform.LookAt(enemiesList[count].transform);
            count++;
        }
        else return;        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            enemiesList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            enemiesList.Remove(other.gameObject);
        }
    }
}
