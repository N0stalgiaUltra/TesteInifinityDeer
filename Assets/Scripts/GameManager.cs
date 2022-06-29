using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> playersList = new List<GameObject>();

    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;

        playersList = GameObject.FindGameObjectsWithTag("Player").ToList();

    }

    
    public GameObject ReturnNearestPlayer(Transform currEnemy)
    {
        float currDist = 0;
        float minDist = 0;
        GameObject aux = null;

        //3,2,5
        for (int i = 0; i < playersList.Count; i++)
        {
            currDist = Vector3.Distance(currEnemy.position, playersList[i].transform.position);

            if (minDist == 0)
                minDist = currDist;

            if (currDist <= minDist)
            {
                minDist = currDist;
                aux = playersList[i].gameObject;
            }
            
        }

        return aux;
    }
}
