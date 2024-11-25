using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;

    public Transform bulletsParent;

    public float playerMoveSpeed;

    public float playerBulletSpeed;

    public float playerXBorder;
    public float playerYBorder;

    public Bullet bulletPrefab;

    public float attackRate;

    public List<Vector3> shootDirections;

    public int startHealth;
    private int _curHealth;

    public Transform healthBarFill;

    public void StartPlayer()
    {
        _curHealth = startHealth;
        StartCoroutine(ShootCoroutine());
    }

    void Update()
    {
        MovePlayer();
        ClampPlayerPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _curHealth -= 1;
            UpdateHealthBar((float)_curHealth / startHealth);
            if (_curHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        if (collision.CompareTag("Coin"))
        {
            gameDirector.coinManager.IncreaseCoinCount(1);
            gameDirector.fxManager.PlayCoinCollectedFX(collision.transform.position);
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("PowerUp"))
        {
            shootDirections.Add(new Vector3(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f, 1f), 0).normalized);
            collision.gameObject.SetActive(false);
        }
    }

    void UpdateHealthBar(float ratio)
    {
        healthBarFill.transform.localScale = new Vector3(ratio, 1f, 1f);
    }


    //Methods
    void ClampPlayerPosition()
    {
        var pos = transform.position;
        if (pos.x > playerXBorder)
        {
            pos.x = playerXBorder;
        }
        else if (pos.x < -playerXBorder)
        {
            pos.x = -playerXBorder;
        }
        if (pos.y > playerYBorder)
        {
            pos.y = playerYBorder;
        }
        else if (pos.y < -playerYBorder)
        {
            pos.y = -playerYBorder;
        }
        transform.position = pos;
    }

    void MovePlayer()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }

        transform.position += direction.normalized * playerMoveSpeed * Time.deltaTime;
    }

    IEnumerator ShootCoroutine()
    {

        while (true)
        {
            yield return new WaitForSeconds(attackRate);

            for (int i = 0; i < shootDirections.Count; i++) 
            {
                Shoot(shootDirections[i]);
            }
        }        
    }

    void Shoot(Vector3 dir)
    {
        var newBullet = Instantiate(bulletPrefab, bulletsParent);
        newBullet.transform.position = transform.position;
        newBullet.StartBullet(playerBulletSpeed, dir, gameDirector);
    }
}
