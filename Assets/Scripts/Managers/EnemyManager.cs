using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Player player;

    public Enemy enemyPrefab;
    public Enemy bossEnemyPrefab;

    public float enemyYSpacing;

    private int _spawnedEnemyCount;

    public void StartEnemyManager()
    {
        StartCoroutine(EnemyGenerationCoroutine());
        _spawnedEnemyCount = 0;
    }    

    IEnumerator EnemyGenerationCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f + Random.Range(0,2f));
            if (_spawnedEnemyCount < 20)
            {
                if (Random.value < .75f)
                {
                    SpawnEnemy();
                }
                else
                {
                    SpawnTwoEnemies();
                }
            }
            else
            {
                yield return new WaitForSeconds(4);
                SpawnBoss();
                break;
            }            
        }
    }
    void SpawnEnemy()
    {
        var newEnemy = Instantiate(enemyPrefab);
        var enemyXPos = Random.Range(-2.2f, 2.2f);
        var enemyYPos = 5 * enemyYSpacing;
        newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);
        _spawnedEnemyCount++;
        newEnemy.StartEnemy(player);
    }

    void SpawnTwoEnemies()
    {
        var newEnemy = Instantiate(enemyPrefab);
        var enemyXPos = Random.Range(1f, 2.2f);
        var enemyYPos = 5 * enemyYSpacing;
        newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);
        _spawnedEnemyCount++;
        newEnemy.StartEnemy(player);

        var newEnemy2 = Instantiate(enemyPrefab);
        var enemyXPos2 = Random.Range(-1f, -2.2f);
        var enemyYPos2 = 5 * enemyYSpacing;
        newEnemy2.transform.position = new Vector3(enemyXPos2, enemyYPos2, 0);
        _spawnedEnemyCount++;
        newEnemy2.StartEnemy(player);
    }

    void SpawnBoss()
    {
        var newEnemy = Instantiate(bossEnemyPrefab);
        var enemyXPos = Random.Range(-2f, 2f);
        var enemyYPos = 5 * enemyYSpacing;
        newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);
        _spawnedEnemyCount++;
        newEnemy.StartEnemy(player);
    }
}
