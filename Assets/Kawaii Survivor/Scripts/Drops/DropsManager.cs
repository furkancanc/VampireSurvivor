using System;
using UnityEngine;
using UnityEngine.Pool;

public class DropsManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Candy candyPrefab;
    [SerializeField] private Cash cashPrefab;

    [Header("Pooling")]
    private ObjectPool<Candy> candyPool;
    private ObjectPool<Cash> cashPool;

    private void Awake()
    {
        Enemy.onPassedAway += EnemyPassedAwayCallback;
        Candy.onCollected += ReleaseCandy;
        Cash.onCollected += ReleaseCash;
    }

    private void OnDestroy()
    {
        Enemy.onPassedAway -= EnemyPassedAwayCallback;
        Candy.onCollected -= ReleaseCandy;
        Cash.onCollected -= ReleaseCash;
    }

    private void Start()
    {
        candyPool = new ObjectPool<Candy>(
            CandyCreateFunction, 
            CandyActionOnGet, 
            CandyActionOnRelease, 
            CandyActionOnDestroy);

        cashPool = new ObjectPool<Cash>(CashCreateFunction, 
            CashActionOnGet, 
            CashActionOnRelease, 
            CashActionOnDestroy);
    }

    private Candy CandyCreateFunction()                 => Instantiate(candyPrefab, transform);
    private void CandyActionOnGet(Candy candy)          => candy.gameObject.SetActive(true);
    private void CandyActionOnRelease(Candy candy)      => candy.gameObject.SetActive(true);
    private void CandyActionOnDestroy(Candy candy)      => Destroy(candy.gameObject);

    private Cash CashCreateFunction()                   => Instantiate(cashPrefab, transform);
    private void CashActionOnGet(Cash cash)             => cash.gameObject.SetActive(true);
    private void CashActionOnRelease(Cash cash)         => cash.gameObject.SetActive(true);
    private void CashActionOnDestroy(Cash cash)         => Destroy(cash.gameObject);

    private void EnemyPassedAwayCallback(Vector2 enemyPosition)
    {
        bool shouldSpawnCash = UnityEngine.Random.Range(0, 101) <= 20;

        DroppableCurrency droppable = shouldSpawnCash ? cashPool.Get() : candyPool.Get();
        DroppableCurrency droppableInstance = Instantiate(droppable, enemyPosition, Quaternion.identity, transform);
    }

    public void ReleaseCandy(Candy candy)               => candyPool.Release(candy);
    public void ReleaseCash(Cash cash)                  => cashPool.Release(cash);
}
