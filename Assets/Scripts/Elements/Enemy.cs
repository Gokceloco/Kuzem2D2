using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startHealth;

    private int _currentHealth;

    public float speed;

    private void Start()
    {
        _currentHealth = startHealth;
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }

    public void GetHit(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
