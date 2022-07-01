using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : EnemyAttack
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator enemyAnim;
    [SerializeField] private GameObject playerTest;
    private bool isMoving;

    public delegate void EnemyAttacked();

    private float counter;
    [SerializeField] private float attackRate = 0.2f;
    private float attackCounter = 0f;

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

        if (Distance(playerTest.transform) <= 2f) AttackMotion();
        else Move();

        enemyAnim.SetBool("Move", isMoving);
    }

    private void Move()
    {
        
        agent.SetDestination(playerTest.transform.position);
        transform.LookAt(playerTest.transform);
        isMoving = true;
    }

    public void AttackMotion()
    {
        isMoving = false;
        agent.SetDestination(this.transform.position);
        transform.LookAt(playerTest.transform);

        if (Distance(playerTest.transform) <= 2.5f && Time.time > attackCounter)
        {
            enemyAnim.SetTrigger("Attack");
            attackCounter = Time.time + attackRate;
        }
    }

    public void DamagePlayer()
    {
        base.Attack(playerTest);
    }
    private float Distance(Transform player)
    {
        return Vector3.Distance(this.transform.position, player.position);
    }

}
