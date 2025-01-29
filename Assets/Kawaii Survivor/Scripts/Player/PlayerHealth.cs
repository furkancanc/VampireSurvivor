using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int health;

    public void TakeDamage(int damage)
    {
        int realDamage = Mathf.Min(damage, health);
        health -= damage;

        if (health <= 0)
        {
            PassAway();
        }
    }

    private void PassAway()
    {
        Debug.Log("Dead");
    }
}

