using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Components")]
    protected EnemyMovement movement;

    [Header("Health")]
    [SerializeField] protected int maxHealth;
    protected int health;

    [Header("Elements")]
    protected Player player;

    [Header("Spawn Sequence Related")]
    [SerializeField] protected SpriteRenderer renderer;
    [SerializeField] protected SpriteRenderer spawnIndicator;
    [SerializeField] protected Collider2D collider;
    protected bool hasSpawned;

    [Header("Attack")]
    [SerializeField] protected float playerDetectionRadius;

    [Header("Effects")]
    [SerializeField] protected ParticleSystem passAwayParticles;

    [Header("Actions")]
    public static Action<int, Vector2> onDamageTaken;

    [Header("DEBUG")]
    [SerializeField] protected bool gizmos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
