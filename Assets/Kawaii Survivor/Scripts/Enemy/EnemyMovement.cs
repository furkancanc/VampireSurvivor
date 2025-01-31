using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Elements")]
    private Player player;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;

    [Header("Range Enemy Related")]
    private float rangePlayerDetectionRadius;
    private bool isRangeEnemy;

    void Update()
    {
        if (player != null)
        {
            FollowPlayer();
        }  
    }

    public void StorePlayer(Player player, bool isRangeEnemy, float rangePlayerDetectionRadius)
    {
        this.player = player;
        this.isRangeEnemy = isRangeEnemy;
        this.rangePlayerDetectionRadius = rangePlayerDetectionRadius;
    }

    private void FollowPlayer()
    {
        if (isRangeEnemy)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer < rangePlayerDetectionRadius)
            {
                return;
            }
        }

        Vector2 direction = (player.transform.position - transform.position).normalized;
        Vector2 targetPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;

        transform.position = targetPosition;
    }
}
