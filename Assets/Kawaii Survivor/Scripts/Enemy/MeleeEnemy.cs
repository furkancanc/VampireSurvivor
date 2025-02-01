using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class MeleeEnemy : Enemy
{
    [Header("Attack")]
    [SerializeField] private int damage;
    [SerializeField] private float attackFrequency;
    [SerializeField] private float playerDetectionRadius;
    private float attackDelay;
    private float attackTimer;

    [Header("Effects")]
    [SerializeField] private ParticleSystem passAwayParticles;

    [Header("Actions")]
    public static Action<int, Vector2> onDamageTaken;

    [Header("DEBUG")]
    [SerializeField] private bool gizmos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();

        attackDelay = 1f / attackFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (attackTimer >= attackDelay)
        {
            TryAttack();
        }
        else
        {
            Wait();
        }

        movement.FollowPlayer();
    }

    private void TryAttack()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= playerDetectionRadius)
        {
            Attack();
        }
    }

    private void Wait()
    {
        attackTimer += Time.deltaTime;
    }

    private void Attack()
    {
        attackTimer = 0;
        player.TakeDamage(damage);
        
        
    }

    private void PassAway()
    {
        passAwayParticles.transform.parent = null;
        passAwayParticles.Play();

        Destroy(gameObject);
    }
}
