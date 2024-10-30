using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
    }
}
