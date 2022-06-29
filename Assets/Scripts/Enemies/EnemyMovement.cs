using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject playerTest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        agent.SetDestination(playerTest.transform.position);
        transform.LookAt(playerTest.transform);

        //agent.SetDestination(GameManager.instance.ReturnNearestPlayer(this.transform).transform.position);
    }

    private void Attack()
    {
        agent.SetDestination(this.transform.position);
        transform.LookAt(playerTest.transform);

    }
}
