using NaughtyAttributes;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using Random = UnityEngine.Random;

public class WaveTransitionManager : MonoBehaviour, IGameStateListener
{
    [Header("Elements")]
    [SerializeField] private UpgradeContainer[] upgradeContainers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.WAVETRANSITION:
                ConfigureUpgradeContainers();
                break;
        }
    }

    [Button]
    private void ConfigureUpgradeContainers()
    {
        for (int i = 0; i < upgradeContainers.Length; ++i)
        {
            int randomIndex = Random.Range(0, Enum.GetValues(typeof(Stat)).Length);
            Stat stat = (Stat)Enum.GetValues(typeof(Stat)).GetValue(randomIndex);

            string randomStatString = Enums.FormatStatName(stat);

            upgradeContainers[i].Configure(null, randomStatString, Random.Range(0, 100).ToString());

            Action action = GetActionToPerform(stat);

            upgradeContainers[i].Button.onClick.RemoveAllListeners();
            upgradeContainers[i].Button.onClick.AddListener(() => action?.Invoke());

        }
    }

    private Action GetActionToPerform(Stat stat)
    {
        switch (stat)
        {
            case Stat.Attack:
                return () => Debug.Log("Improving Attack by " + 5);
            case Stat.Range:
                return () => Debug.Log("Improving Range by " + 5);
            case Stat.MoveSpeed:
                return () => UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            default:
                return () => Debug.Log("Invalid stat");
        }
    }
}
