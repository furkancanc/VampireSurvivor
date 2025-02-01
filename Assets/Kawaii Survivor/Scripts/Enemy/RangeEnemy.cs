using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(RangeEnemyAttack))]
public class RangeEnemy : Enemy
{
    private RangeEnemyAttack attack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();

        attack = GetComponent<RangeEnemyAttack>();
        attack.StorePlayer(player);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        ManageAttack();
    }

    private void ManageAttack()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer > playerDetectionRadius)
        {
            movement.FollowPlayer();
        }
        else
        {
            TryAttack();
        }
    }

    private void TryAttack()
    {
        attack.AutoAim();
    }
}
