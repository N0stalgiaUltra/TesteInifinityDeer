using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : EnemyAttack
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator enemyAnim;
    private GameObject playerTest;
    private bool isMoving;

    public delegate void EnemyAttacked();

    [SerializeField] private float counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0f;
        playerTest = GameManager.instance.ReturnNearestPlayer(this.transform);
    }

    private void Update()
    {
        counter += Time.deltaTime;

        if(counter >= 5f)
        {
            playerTest = GameManager.instance.ReturnNearestPlayer(this.transform);
            counter = 0f;
        }

        if (Distance(playerTest.transform) <= 2.5f) Attack(playerTest);
        else Move();

        enemyAnim.SetBool("Move", isMoving);
    }

    private void Move()
    {
        
        agent.SetDestination(playerTest.transform.position);
        transform.LookAt(playerTest.transform);
        isMoving = true;
    }

    protected override void Attack(GameObject player)
    {
        isMoving = false;
        
        agent.SetDestination(this.transform.position);
        transform.LookAt(playerTest.transform);

        if (Distance(playerTest.transform) < 3f)
            base.Attack(playerTest);

    }
    private float Distance(Transform player)
    {
        //distancia pra atacar é 3;
        return Vector3.Distance(this.transform.position, player.position);
    }

}
