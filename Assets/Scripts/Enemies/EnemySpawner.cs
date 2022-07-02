using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private HordeManager hordeManager;
    [SerializeField] private List<EnemyData> enemiesType = new List<EnemyData>(3);
    [SerializeField] private List<float> spawnChance = new List<float>(3);

    private Queue<GameObject> enemyPool = new Queue<GameObject>();
    void Awake()
    {
        int aux = hordeManager.TotalEnemies;

        for (int i = 0; i < enemiesType.Count; i++)
        {
            spawnChance.Add(enemiesType[i].spawnPercentage);
        }

        for (int i = 0; i < aux; i++)
        {
            GameObject aux2 = Instantiate(enemiesType[GetRandomSpawn()].prefab, this.transform);
            aux2.SetActive(false);
            enemyPool.Enqueue(aux2);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //    ActivateEnemies();
            //Instantiate(enemiesType[GetRandomSpawn()].prefab, this.transform).SetActive(false);

    }

    private int GetRandomSpawn()
    {
        float random = Random.Range(0f,1f);
        float aux = 0;
        float total = 0;

        for (int i = 0; i < spawnChance.Count; i++)
            total += spawnChance[i];

        for (int i = 0; i < enemiesType.Count; i++)
        {
            if (spawnChance[i] / total + aux >= random)
                return i;
            else 
                aux += spawnChance[i] / total;
        }

        return 0;
    }
        
    private void ActivateEnemies()
    {
        int aux = hordeManager.EnemiesPerRound(hordeManager.actualRound-1);
        
        for (int i = 0; i < aux; i++)
        {
            enemyPool.Dequeue().SetActive(true);
        }
    }

    private void DeactivateEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }
}
