using System.Collections.Generic;
using UnityEngine;

public static class WeaponStatsCalculator
{
    public static Dictionary<Stat, float> GetStats(WeaponDataSO weaponData, int level)
    {
        float multiplier = 1 + (float)level / 3;

        Dictionary<Stat, float> calculatedStats = new Dictionary<Stat, float>();

        foreach(KeyValuePair<Stat, float> kvp in weaponData.BaseStats)
        {
            if (weaponData.Prefab.GetType() != typeof(RangeWeapon)
                && kvp.Key == Stat.Range)
            {
                calculatedStats.Add(kvp.Key, kvp.Value);
            }
            else
            {
                calculatedStats.Add(kvp.Key, kvp.Value * multiplier);
            }
        }

        return calculatedStats;
    }
}
