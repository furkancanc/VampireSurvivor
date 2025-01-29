using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Elements")]
    private Player player;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float playerDetectionRadius;

    [Header("Effects")]
    [SerializeField] private ParticleSystem passAwayParticles;

    [Header("DEBUG")]
    [SerializeField] private bool gizmos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();

        if (player == null)
        {
            Debug.Log("No player found, Auto-destroying.");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();

        TryAttack();
    }

    private void FollowPlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        Vector2 targetPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;

        transform.position = targetPosition;
    }

    private void TryAttack()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= playerDetectionRadius)
        {
            PassAway();
        }
    }

    private void PassAway()
    {
        // Unparent the particle & play them
        passAwayParticles.transform.parent = null;
        passAwayParticles.Play();

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        if (!gizmos) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerDetectionRadius);
    }
}
