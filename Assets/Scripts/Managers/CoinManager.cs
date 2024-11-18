using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int collectedCoinCount;

    public void IncreaseCoinCount(int count)
    {
        collectedCoinCount += count;
    }
}
