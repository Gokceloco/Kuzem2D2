using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    public ParticleSystem coinCollectesPS;
    public ParticleSystem bulletHitPS;
    public ParticleSystem playerHitPS;
    public void PlayCoinCollectedFX(Vector3 pos)
    {
        var newPS = Instantiate(coinCollectesPS);
        newPS.transform.position = pos;
        newPS.Play();
    }
    public void PlayBulletHitFX(Vector3 pos)
    {
        var newPS = Instantiate(bulletHitPS);
        newPS.transform.position = pos;
        newPS.Play();
    }
    public void PlayPlayerHitFX(Vector3 pos)
    {
        var newPS = Instantiate(playerHitPS);
        newPS.transform.position = pos;
        newPS.Play();
    }
}
