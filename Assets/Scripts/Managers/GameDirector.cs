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
        StartGame();
    }
    void StartGame()
    {
        player.StartPlayer();
        enemyManager.StartEnemyManager();
    }
}
