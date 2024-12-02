using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public CanvasGroup failCanvasGroup;
    public CanvasGroup victoryCanvasGroup;
    public TextMeshProUGUI levelTMP;
    
    public void RestartMainUI()
    {
        failCanvasGroup.gameObject.SetActive(false);
        victoryCanvasGroup.gameObject.SetActive(false);
    }
    public void LevelFailed()
    {
        failCanvasGroup.gameObject.SetActive(true);
    }

    public void SetLevelText(int l)
    {
        levelTMP.text = "LEVEL " + l;
    }

    public void LevelCompleted()
    {
        victoryCanvasGroup.gameObject.SetActive(true);
    }
}
