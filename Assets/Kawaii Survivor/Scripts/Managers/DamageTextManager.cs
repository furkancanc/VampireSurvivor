using UnityEngine;

public class DamageTextManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private DamageText damageTextPrefab;


    private void Awake()
    {
        Enemy.onDamageTaken += InstantiateDamageText;
    }

    private void OnDestroy()
    {
        Enemy.onDamageTaken -= InstantiateDamageText;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [NaughtyAttributes.Button]
    private void InstantiateDamageText(int damage, Vector2 enemyPosition)
    {
        Vector3 spawnPosition = enemyPosition + Vector2.up * 1.5f;

        DamageText damageTextInstance = Instantiate(damageTextPrefab, spawnPosition, Quaternion.identity, transform);
        damageTextInstance.Animate(damage);
    }
}
