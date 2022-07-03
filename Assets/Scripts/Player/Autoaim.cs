using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoaim : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesList = new List<GameObject>();
    [SerializeField] private Transform player;

    [SerializeField] private int count;
    private string enemyTag;

    void Start()
    {
        InputManager.playerAimed += AutoAim;
        count = 0;
    }

    private void AddToList(GameObject aux)
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
    private void RemoveFromList(GameObject aux)
    {
        if (enemyTag.Equals("InimigoPadrao") ||
            enemyTag.Equals("InimigoForte") ||
            enemyTag.Equals("InimigoRapido"))
            {
                enemiesList.Remove(aux);
            }
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
        AddToList(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        enemyTag = other.tag; 
        RemoveFromList(other.gameObject);
    }
}
