using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bulletAS;
    public AudioSource enemyDestroyAS;

    public void PlayBulletAS()
    {
        bulletAS.Play();
    }
    public void PlayEnemyDestroyAS()
    {
        enemyDestroyAS.Play();
    }
}
