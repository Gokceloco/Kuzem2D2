using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;

    public float enemyYSpacing;

    public int enemyCount;

    public void StartEnemyManager()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++) 
        {
            var newEnemy = Instantiate(enemyPrefab);
            var enemyXPos = Random.Range(-2.2f, 2.2f);
            var enemyYPos = 6 + i * enemyYSpacing;
            newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);
        }              
    }
}
