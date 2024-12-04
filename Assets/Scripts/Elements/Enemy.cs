using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player;

    public int startHealth;

    private int _currentHealth;

    public float speed;

    public TextMeshPro healthTMP;

    public SpriteRenderer spriteRenderer;

    public float flashDuration;

    public Coin coinPrefab;
    public PowerUp powerUpPrefab;

    private bool _isEnemyDestroyed;

    public EnemyType enemyType;

    private Coroutine _shootCoroutine;

    public Bullet bulletPrefab;
    public float attackRate;
    public float bulletSpeed;

    public void StartEnemy(Player player)
    {
        _player = player;
        startHealth += Random.Range(0, 10);
        startHealth += 10 * (player.shootDirections.Count - 1);
        _currentHealth = startHealth;
        healthTMP.text = _currentHealth.ToString();
    } 

    void Update()
    {
        if (enemyType == EnemyType.Shooting)
        {
            if (transform.position.y > 3)
            {
                transform.position += Vector3.down * Time.deltaTime * speed;
            }
            else if (_shootCoroutine == null)
            {
                _shootCoroutine = StartCoroutine(ShootCoroutine());
            }
        }
        else
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }

    IEnumerator ShootCoroutine()
    {

        while (true)
        {
            yield return new WaitForSeconds(attackRate);
            var dir = (_player.transform.position - transform.position).normalized;
            Shoot(dir);
        }
    }
    void Shoot(Vector3 dir)
    {
        var newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = transform.position;
        newBullet.StartBullet(bulletSpeed, dir, _player.gameDirector);
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
        spriteRenderer.DOColor(Color.white, flashDuration).SetLoops(2, LoopType.Yoyo);

        if (_currentHealth <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        if (!_isEnemyDestroyed)
        {
            if (enemyType != EnemyType.Boss)
            {
                if (Random.value < .5f)
                {
                    var newCoin = Instantiate(coinPrefab);
                    newCoin.transform.position = transform.position + Vector3.forward * .8f;
                    newCoin.StartCoin();
                }
                else
                {
                    var newPowerUp = Instantiate(powerUpPrefab);
                    newPowerUp.transform.position = transform.position + Vector3.forward * .8f;
                    newPowerUp.StartPowerUp();
                }
            }
            else
            {
                _player.gameDirector.LevelCompleted();
            }

            _isEnemyDestroyed = true;
            
            _player.gameDirector.audioManager.PlayEnemyDestroyAS();
        }

        gameObject.SetActive(false);
    }
}

public enum EnemyType
{
    Basic,
    Fast,
    Shooting,
    Boss,
}