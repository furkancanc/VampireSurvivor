using NaughtyAttributes;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Object Data", menuName = "Scriptable Objects/New Object", order = 0)]
public class ObjectDataSO : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public int Price { get; private set; }

    [field: Range(0, 3)]
    [field: SerializeField] public int Rarity { get; private set; }

    [SerializeField] private StatData[] statDatas;

    [HorizontalLine]
    [SerializeField] private float attack;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float criticalChance;
    [SerializeField] private float criticalPercent;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float range;
    [SerializeField] private float healthRecoverySpeed;
    [SerializeField] private float armor;
    [SerializeField] private float luck;
    [SerializeField] private float dodge;
    [SerializeField] private float lifeSteal;

    public Dictionary<Stat, float> BaseStats
    {
        get
        {
            Dictionary<Stat, float> stats = new Dictionary<Stat, float>();

            foreach (StatData data in statDatas)
                stats.Add(data.stat, data.value);

            return stats;
        }
        private set { }
    }
}

[System.Serializable]
public struct StatData
{
    public Stat stat;
    public float value;
}