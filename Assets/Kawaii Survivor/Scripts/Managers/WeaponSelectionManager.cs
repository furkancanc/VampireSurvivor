using UnityEngine;

public class WeaponSelectionManager : MonoBehaviour, IGameStateListener
{
    [Header("Elements")]
    [SerializeField] private Transform containersParent;
    [SerializeField] private WeaponSelectionContainer weaponContainerPrefab;
    [SerializeField] private PlayerWeapons playerWeapons;

    [Header("Data")]
    [SerializeField] private WeaponDataSO[] starterWeapons;
    private WeaponDataSO selectedWeapon;
    private int initialWeaponLevel;

    public void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.GAME:
                if (selectedWeapon == null)
                    return;

                playerWeapons.AddWeapon(selectedWeapon, initialWeaponLevel);
                selectedWeapon = null;
                initialWeaponLevel = 0;

                break;

            case GameState.WEAPONSELECTION:
                Configure();
                break;
        }
    }

    private void Configure()
    {
        // Clean our parent, no children
        containersParent.Clear();

        // Generate weapon containers
        for (int i = 0; i < 3; ++i)
        {
            GenerateWeaponContainer();
        }
    }

    private void GenerateWeaponContainer()
    {
        WeaponSelectionContainer containerInstance = Instantiate(weaponContainerPrefab, containersParent.transform);

        WeaponDataSO weaponData = starterWeapons[Random.Range(0, starterWeapons.Length)];

        int level = Random.Range(0, 4);
        containerInstance.Configure(weaponData, level);

        containerInstance.Button.onClick.RemoveAllListeners();
        containerInstance.Button.onClick.AddListener(() => WeaponSelectedCallback(containerInstance, weaponData, level));
    }

    private void WeaponSelectedCallback(WeaponSelectionContainer containerInstance, WeaponDataSO weaponData, int level)
    {
        selectedWeapon = weaponData;
        initialWeaponLevel = level;

        foreach (WeaponSelectionContainer container in containersParent.GetComponentsInChildren<WeaponSelectionContainer>())
        {
            if (container == containerInstance)
            {
                container.Select();
            }
            else
            {
                container.Deselect();
            }
        }
    }
}
