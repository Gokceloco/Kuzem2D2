using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public EnemyManager enemyManager;
    public CoinManager coinManager;
    public FxManager fxManager;

    public Player player;

    void Start()
    {
        RestartLevel();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
    public void RestartLevel()
    {
        player.RestartPlayer();
        enemyManager.RestartEnemyManager();
    }

    public void LevelFailed()
    {
        print("in level failed");
    }
}
