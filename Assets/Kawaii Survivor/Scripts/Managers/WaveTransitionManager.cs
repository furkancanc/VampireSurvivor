using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveTransitionManager : MonoBehaviour, IGameStateListener
{
    [Header("Elements")]
    [SerializeField] private Button[] upgradeContainers;

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

    private void ConfigureUpgradeContainers()
    {
        for (int i = 0; i < upgradeContainers.Length; ++i)
        {
            upgradeContainers[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Upgrade " + i;

        }
    }
}
