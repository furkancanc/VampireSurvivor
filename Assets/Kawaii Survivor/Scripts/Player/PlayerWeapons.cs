using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddWeapon(WeaponDataSO selectedWeapon, int weaponLevel)
    {
        Debug.Log(selectedWeapon.Name);
    }
}
