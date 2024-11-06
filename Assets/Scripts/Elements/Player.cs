using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerMoveSpeed;

    public float playerBulletSpeed;

    public float playerXBorder;
    public float playerYBorder;

    public Bullet bulletPrefab;

    private void Start()
    {

    }
    void Update()
    {
        MovePlayer();
        ClampPlayerPosition();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("Collectable"))
        {
            collision.gameObject.SetActive(false);
        }
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

    void Shoot()
    {
        var newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = transform.position;
        newBullet.StartBullet(playerBulletSpeed);
    }
}
