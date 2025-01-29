using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int maxHealth;
    private int health;

    [Header("Elements")]
    [SerializeField] private Slider healthSlider;

    private void Start()
    {
        health = maxHealth;

        healthSlider.value = 1f;

        Debug.Log("Health initialized to: " + health);
    }

    public void TakeDamage(int damage)
    {
        int realDamage = Mathf.Min(damage, health);
        health -= damage;

        float healthBarValue = (float)health / maxHealth;
        healthSlider.value = healthBarValue;

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

