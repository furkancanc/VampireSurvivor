using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Elements")]
    private Player player;

    [Header("Spawn Sequence Related")]
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private SpriteRenderer spawnIndicator;

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

        // Hide the renderer
        renderer.enabled = false;

        // Show the spawn indicator
        spawnIndicator.enabled = true;

        // Scale up & down the spawn indicator
        Vector3 targetScale = spawnIndicator.transform.localScale * 1.2f;
        LeanTween.scale(spawnIndicator.gameObject, targetScale, .3f)
            .setLoopPingPong(4)
            .setOnComplete(SpawnSequenceCompleted);
        

        // Prevent Following & Attacking during the spawn sequence
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();

        TryAttack();
    }

    private void SpawnSequenceCompleted()
    {
        // Show the enemy after 3 seconds
        // Hide the spawn indicator

        // Show the renderer
        renderer.enabled = true;

        // Hide the spawn indicator
        spawnIndicator.enabled = false;

        moveSpeed = 1;
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
