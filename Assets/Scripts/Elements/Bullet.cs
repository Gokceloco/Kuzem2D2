using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    private Vector3 _dir;

    public void StartBullet(float bulletSpeed, Vector3 direction)
    {
        _speed = bulletSpeed;
        _dir = direction;
    }

    void Update()
    {
        transform.position += _dir * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            collision.GetComponent<Enemy>().GetHit(1);
        }
        if (collision.CompareTag("Border"))
        {
            gameObject.SetActive(false);
        }
    }
}
