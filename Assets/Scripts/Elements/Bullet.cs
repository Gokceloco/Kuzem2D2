using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;

    public void StartBullet(float bulletSpeed)
    {
        _speed = bulletSpeed;
    }

    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
}
