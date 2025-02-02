using System;
using UnityEngine;

public class DropsManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Candy candyPrefab;

    private void Awake()
    {
        Enemy.onPassedAway += EnemyPassedAwayCallback;
    }

    private void OnDestroy()
    {
        Enemy.onPassedAway -= EnemyPassedAwayCallback;
    }

    private void EnemyPassedAwayCallback(Vector2 enemyPosition)
    {
        Instantiate(candyPrefab, enemyPosition, Quaternion.identity, transform);
    }
}
