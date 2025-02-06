using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class PlayerHealth : MonoBehaviour, IPlayerStatsDependency
{
    [Header("Settings")]
    [SerializeField] private int baseMaxHealth;
    private float maxHealth;
    private float health;
    private float armor;
    private float lifeSteal;
    private float dodge;

    [Header("Elements")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;

    [Header("Actions")]
    public static Action<Vector2> onAttackDodged;

    private void Start()
    {
        Enemy.onDamageTaken += EnemyTookDamageCallback;   
    }

    private void OnDestroy()
    {
        Enemy.onDamageTaken -= EnemyTookDamageCallback;
    }

    private void EnemyTookDamageCallback(int damage, Vector2 enemyPosition, bool isCriticalHit)
    {
        if (health >= maxHealth)
        {
            return;
        }

        float lifeStealValue = damage * lifeSteal;
        float healthToAdd = Mathf.Min(lifeStealValue, maxHealth - health);

        health += healthToAdd;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        if (ShouldDodge())
        {
            onAttackDodged?.Invoke(transform.position);
            return;
        }

        float realDamage = damage * Mathf.Clamp(1 - (armor / 1000), 0, 10000); 
        realDamage = Mathf.Min(damage, health);
        health -= damage;

        Debug.Log("Real Damage : " + realDamage);

        UpdateUI();
        if (health <= 0)
        {
            PassAway();
        }
    }

    private bool ShouldDodge()
    {
        return Random.Range(0f, 100f) < dodge;
    }

    private void PassAway()
    {
        GameManager.instance.SetGameState(GameState.GAMEOVER);
    }

    private void UpdateUI()
    {
        float healthBarValue = health / maxHealth;
        healthSlider.value = healthBarValue;

        healthText.text = (int)health + " / " + maxHealth;
    }

    public void UpdateStats(PlayerStatsManager playerStatsManager)
    {
        float addedHealth = playerStatsManager.GetStatValue(Stat.MaxHealth);
        maxHealth = baseMaxHealth + (int)addedHealth;
        maxHealth = Mathf.Max(maxHealth, 1);

        health = maxHealth;
        UpdateUI();

        armor = playerStatsManager.GetStatValue(Stat.Armor);
        lifeSteal = playerStatsManager.GetStatValue(Stat.LifeSteal) / 100;
        dodge = playerStatsManager.GetStatValue(Stat.Dodge);
    }
}

