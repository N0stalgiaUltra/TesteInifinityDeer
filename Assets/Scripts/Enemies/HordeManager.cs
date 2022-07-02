using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeManager : MonoBehaviour
{
    //numero de hordas. ex: 1,2,3
    //numero de inimigos para cada horda
    //numero de inimigos por horda

    [SerializeField] private int hordeNumber = 3;
    [SerializeField] private int initialEnemiesCount = 10;
    [SerializeField] private int fixEnemyIncrease = 5;
    public int actualRound;
    private int totalEnemiesCount;

    private void Awake()
    {
        totalEnemiesCount = initialEnemiesCount + (hordeNumber * fixEnemyIncrease);
        actualRound = 1;
    }

   
    public int EnemiesPerRound(int i) 
    {
        return initialEnemiesCount + (i * fixEnemyIncrease);
    }

    public void EndRound()
    {
        //se matou todos os inimigos dessa horda, termina o round
    }

    public void StartRound()
    {

    }

    public int TotalEnemies { get => totalEnemiesCount; }
}
//horda 1 = 10 inimigos, i=0, +0 inimigos
//horda 2 = 15 inimigos, i=1, +5 inimigos
//horda 3 = 20 inimigos, i=2, +10 inimigos 