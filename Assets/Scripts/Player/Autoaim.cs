using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoaim : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesList = new List<GameObject>();
    [SerializeField] private Transform player;

    [SerializeField] private int count;
    private string enemyTag;
    private GameObject aux;

    void Start()
    {
        InputManager.playerAimed += AutoAim;
        count = 0;
    }

    private void AddToList()
    {
        if (enemyTag.Equals("InimigoPadrao") ||
            enemyTag.Equals("InimigoForte") || 
            enemyTag.Equals("InimigoRapido"))
        {
            enemiesList.Add(aux);
            aux = null;
        }
        else
            return;
        
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
        enemyTag = other.tag;
        aux = other.gameObject;
        AddToList();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            enemiesList.Remove(other.gameObject);
        }
    }
}
