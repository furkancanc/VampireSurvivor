using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [Header("Settings")]
    private Dictionary<Stat, float> statDatas = new Dictionary<Stat, float>();

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
        if (statDatas.ContainsKey(stat))
        {
            statDatas[stat] += value;
        }
        else
        {
            Debug.LogError($"The key {stat} has not been found, this is not normal behaviour!");
        }
    }
}
