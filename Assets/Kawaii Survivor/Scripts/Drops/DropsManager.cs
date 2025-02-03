using System;
using UnityEngine;

public class DropsManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Candy candyPrefab;
    [SerializeField] private Cash cashPrefab;

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
        bool shouldSpawnCash = UnityEngine.Random.Range(0, 101) <= 20;

        GameObject droppable = shouldSpawnCash ? cashPrefab.gameObject : candyPrefab.gameObject;
        GameObject droppableInstance = Instantiate(droppable, enemyPosition, Quaternion.identity, transform);

    }
}
