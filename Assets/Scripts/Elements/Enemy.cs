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

    private void Start()
    {
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
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
