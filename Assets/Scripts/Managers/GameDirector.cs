using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public EnemyManager enemyManager;
    public CoinManager coinManager;
    public FxManager fxManager;
    public AudioManager audioManager;

    public Player player;

    public MainUI mainUI;

    public int levelNo;

    void Start()
    {
        SetInitalLevel();
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
        levelNo = PlayerPrefs.GetInt("HighestLevelReached");
        player.RestartPlayer();
        enemyManager.RestartEnemyManager();
        mainUI.RestartMainUI();
        mainUI.SetLevelText(levelNo);
    }

    public void LevelFailed()
    {
        mainUI.LevelFailed();
    }

    public void SetInitalLevel()
    {
        var initialLevel = PlayerPrefs.GetInt("HighestLevelReached");
        if (initialLevel == 0)
        {
            initialLevel = 1;
        }
        PlayerPrefs.SetInt("HighestLevelReached", initialLevel);
    }

    public void LevelCompleted()
    {
        player.StopShooting();
        PlayerPrefs.SetInt("HighestLevelReached", PlayerPrefs.GetInt("HighestLevelReached") + 1);
        mainUI.LevelCompleted();
    }
}
