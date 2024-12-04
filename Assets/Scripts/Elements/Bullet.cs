using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameDirector _gameDirector;
    private float _speed;
    private Vector3 _dir;

    public BulletType bulletType;

    public void StartBullet(float bulletSpeed, Vector3 direction, GameDirector gameDirector)
    {
        _speed = bulletSpeed;
        _dir = direction;
        _gameDirector = gameDirector;
    }

    void Update()
    {
        transform.position += _dir * Time.deltaTime * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && bulletType == BulletType.Player)
        {
            collision.GetComponent<Enemy>().GetHit(1);
            _gameDirector.fxManager.PlayBulletHitFX(transform.position);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player") && bulletType == BulletType.Enemy)
        {
            collision.GetComponent<Player>().GetHit();
            Destroy(gameObject);
        }
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
public enum BulletType
{
    Player,
    Enemy,
}