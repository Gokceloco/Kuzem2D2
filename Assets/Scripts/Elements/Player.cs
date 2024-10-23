using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerMoveSpeed;

    public float playerXBorder;
    public float playerYBorder;

    void Update()
    {
        MovePlayer();        
        ClampPlayerPosition();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
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
    void ClampPlayerPosition()
    {
        var pos = transform.position;
        if (transform.position.x < -playerXBorder)
        {
            pos.x = -playerXBorder;
        }
        if (transform.position.x > playerXBorder)
        {
            pos.x = playerXBorder;
        }
        if (transform.position.y < -playerYBorder)
        {
            pos.y = -playerYBorder;
        }
        if (transform.position.y > playerYBorder)
        {
            pos.y = playerYBorder;
        }
        transform.position = pos;
    }
    void Shoot()
    {
        print("Shoot");
    }
}
