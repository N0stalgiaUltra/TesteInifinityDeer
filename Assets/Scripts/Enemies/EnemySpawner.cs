using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private HordeManager hordeManager;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private List<EnemyData> enemiesType = new List<EnemyData>(3);
    [SerializeField] private List<float> spawnChance = new List<float>(3);
    [SerializeField] private List<Transform> spawnPosition = new List<Transform>(3);

    private Queue<GameObject> enemyPool = new Queue<GameObject>();
    void Start()
    {
        int aux = hordeManager.totalEnemiesCount;
        for (int i = 0; i < enemiesType.Count; i++)
            spawnChance.Add(enemiesType[i].spawnPercentage);
        
        FillQueue(aux);
        
    }

    private void FillQueue(int aux)
    {
        for (int i = 0; i < aux; i++)
        {
            GameObject aux2 = Instantiate(enemiesType[GetRandomSpawn()].prefab, spawnPosition[Random.Range(0,3)]);
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
        
    public void ActivateEnemies(int aux)
    {
        if(enemyPool.Count == 0)
        {
            FillQueue(aux);
        }
        else
        {
            StartCoroutine(DequeueEnemies(aux));
            
        }
    
    }

    IEnumerator DequeueEnemies(int aux)
    {
        for (int i = 0; i < aux; i++)
        {
            enemyPool.Dequeue().SetActive(true);
            yield return new WaitForSeconds(.5f);
        }
    }

    public void DeactivateEnemy(GameObject enemy, EnemyData data)
    {
        scoreManager.SetScore(data.score);
        hordeManager.KillCount++;
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }

}
