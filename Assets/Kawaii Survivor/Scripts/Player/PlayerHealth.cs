using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int maxHealth;
    private int health;

    private void Start()
    {
        health = maxHealth;
        Debug.Log("Health initialized to: " + health);
    }

    public void TakeDamage(int damage)
    {
        int realDamage = Mathf.Min(damage, health);
        health -= damage;

        Debug.Log("Health : " + health);

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

