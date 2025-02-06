using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [Header("Settings")]
    private Dictionary<Stat, StatData> addens = new Dictionary<Stat, StatData>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayerStat(Stat stat, float value)
    {
        //if (statDatas.ContainsKey(stat))
        //{
        //    statDatas[stat] += value;
        //}
        //else
        //{
        //    Debug.LogError($"The key {stat} has not been found, this is not normal behaviour!");
        //}

        StatData dataToAdd = new StatData(stat, value);
        addens[stat] += dataToAdd;

    }
}

public struct StatData
{
    public Stat stat;
    public float value;

    public StatData(Stat stat, float value)
    {
        this.stat = stat;
        this.value = value;
    }

    public static StatData operator +(StatData data1, StatData data2)
    {
        if (data1.stat != data2.stat)
        {
            Debug.LogError("Invalid operation, the Stats are not the same.");
            return data1;
        }

        float result = data1.value + data2.value;

        return new StatData(data1.stat, result);
    }
    public static StatData operator -(StatData data1, StatData data2)
    {
        return data1 + new StatData(data2.stat, -data2.value);
    }
}
