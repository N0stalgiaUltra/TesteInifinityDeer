using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private GameObject playerTest;

    // Start is called before the first frame update
    void Start()
    {
        playerTest = GameManager.instance.ReturnNearestPlayer(this.transform);
    }

    private void Update()
    {
        if (Distance(playerTest.transform) <= 3.5f) Attack();
        else Move();

    }

    private void Move()
    {
        agent.SetDestination(playerTest.transform.position);
        transform.LookAt(playerTest.transform);
    }

    private void Attack()
    {
        agent.SetDestination(this.transform.position);
        transform.LookAt(playerTest.transform);

    }
    private float Distance(Transform player)
    {
        //distancia pra atacar é 3;
        return Vector3.Distance(this.transform.position, player.position);
    }

}
