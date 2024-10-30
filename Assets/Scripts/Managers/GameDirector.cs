using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public EnemyManager enemyManager;

    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        enemyManager.StartEnemyManager();
    }
}
