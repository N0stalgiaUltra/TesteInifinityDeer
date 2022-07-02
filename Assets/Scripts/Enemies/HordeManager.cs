using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeManager : MonoBehaviour
{

    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private int hordeNumber = 3;
    [SerializeField] private int initialEnemiesCount = 10;
    [SerializeField] private int fixEnemyIncrease = 5;
   
    public int actualRound;
    [SerializeField] private int killCount;
    private int totalEnemiesCount;

    private void Awake()
    {
        totalEnemiesCount = initialEnemiesCount + (hordeNumber * fixEnemyIncrease);
        actualRound = 1;
    }
    private void Update()
    {
        if (killCount >= EnemiesPerRound(actualRound-1))
            EndRound();

    }
    public int EnemiesPerRound(int i) 
    {
        return initialEnemiesCount + (i * fixEnemyIncrease);
    }

    public void EndRound()
    {
        actualRound++;
        if (actualRound >= hordeNumber)
            EndLevel();
        else
            StartCoroutine(WaitToRestart());
    }
    IEnumerator WaitToRestart()
    {
        yield return new WaitForSecondsRealtime(3f);
        StartRound();
    }
    public void StartRound()
    {
        killCount = 0;
        enemySpawner.ActivateEnemies(EnemiesPerRound(actualRound-1));
    }
    public void EndLevel()
    {
        GameManager.instance.GameOver(true);
    }
    public int TotalEnemies { get => totalEnemiesCount; }
    public int KillCount { get => killCount; set => killCount = value; }
}

