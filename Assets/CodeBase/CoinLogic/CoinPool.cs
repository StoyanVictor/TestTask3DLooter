using System.Collections.Generic;
using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;
public class CoinPool : MonoBehaviourExtBind
{
    [Header("Pool")]
    [SerializeField] private Coin coinPrefab;
    [SerializeField] private int poolSize = 1000;
    [SerializeField] private Transform poolRoot;

    [SerializeField] private int activeCoins;
    private Queue<Coin> pool = new Queue<Coin>();
    
    [OnAwake]
    private void CreatePool()
    {
        if (poolRoot == null)
        {
            GameObject go = new GameObject("CoinPoolRoot");
            poolRoot = go.transform;
            poolRoot.SetParent(transform);
        }

        for (int i = 0; i < poolSize; i++)
        {
            Coin c = Instantiate(coinPrefab, poolRoot);
            c.gameObject.SetActive(false);
            pool.Enqueue(c);
        }

        Model.Set("CoinPool", this);
    }
   
    public Coin GetCoin(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            Debug.LogWarning("CoinPool: пул пуст. Создаю новую монету (poolSize возможно слишком мал).");
            Coin cNew = Instantiate(coinPrefab, poolRoot);
            cNew.gameObject.SetActive(false);
            pool.Enqueue(cNew);
        }

        Coin coin = pool.Dequeue();
        coin.transform.position = position;
        coin.transform.rotation = rotation;
        coin.gameObject.SetActive(true);
        activeCoins++;
        return coin;
    }
    
    [Bind("ReturnCoin")]
    public void ReturnCoin(Coin coin)
    {
            coin.gameObject.SetActive(false);
            coin.transform.SetParent(poolRoot);
            pool.Enqueue(coin);
            activeCoins--;
    }
    
    public int GetPoolCount => poolSize;
    public int GetActiveCoinsCount => activeCoins;
}