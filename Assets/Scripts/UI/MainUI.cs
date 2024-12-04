using DG.Tweening;
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
        failCanvasGroup.alpha = 0;
        victoryCanvasGroup.gameObject.SetActive(false);
        victoryCanvasGroup.alpha = 0;
    }
    public void LevelFailed()
    {
        failCanvasGroup.gameObject.SetActive(true);
        failCanvasGroup.DOFade(1, .5f);
    }

    public void SetLevelText(int l)
    {
        levelTMP.text = "LEVEL " + l;
    }

    public void LevelCompleted()
    {
        victoryCanvasGroup.gameObject.SetActive(true);
        victoryCanvasGroup.DOFade(1, .5f);
    }
}
