using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator enemyAnim;
    
    private GameObject currentPlayer;
    private bool isMoving;

    private float counter;
    private float attackRate = 1f;
    private float attackCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0f;
        currentPlayer = PlayerFinder.instance.ReturnNearestPlayer(this.transform);
    }

    private void Update()
    {
        counter += Time.deltaTime;

        if(counter >= 5f)
        {
            currentPlayer = PlayerFinder.instance.ReturnNearestPlayer(this.transform);
            counter = 0f;
        }

        if (Distance(currentPlayer.transform) <= 2f) AttackMotion();
        else Move();

        enemyAnim.SetBool("Move", isMoving);
    }

    private void Move()
    {
        
        agent.SetDestination(currentPlayer.transform.position);
        transform.LookAt(currentPlayer.transform);
        isMoving = true;
    }

    public void AttackMotion()
    {
        isMoving = false;
        agent.SetDestination(this.transform.position);
        transform.LookAt(currentPlayer.transform);

        if (Distance(currentPlayer.transform) <= 2.5f && Time.time > attackCounter)
        {
            enemyAnim.SetTrigger("Attack");
            attackCounter = Time.time + attackRate;
        }
    }

    public void DamagePlayer()
    {
        currentPlayer.GetComponent<PlayerHealth>().Damage(enemyData.damage);
    }
    private float Distance(Transform player)
    {
        return Vector3.Distance(this.transform.position, player.position);
    }

}
