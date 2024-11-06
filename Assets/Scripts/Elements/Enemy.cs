using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startHealth;

    private int _currentHealth;

    public float speed;

    public TextMeshPro healthTMP;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        startHealth += Random.Range(0,10);
        _currentHealth = startHealth;
        healthTMP.text = _currentHealth.ToString();
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }

    public void GetHit(int damage)
    {
        _currentHealth -= damage;
        healthTMP.text = _currentHealth.ToString();

        transform.DOKill();
        transform.localScale = Vector3.one;
        transform.DOScale(1.2f, .1f).SetLoops(2, LoopType.Yoyo);

        spriteRenderer.DOKill();
        spriteRenderer.color = Color.red;
        spriteRenderer.DOColor(Color.white, .1f).SetLoops(2, LoopType.Yoyo);

        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
