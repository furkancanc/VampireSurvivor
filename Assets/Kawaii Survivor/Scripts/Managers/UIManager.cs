using UnityEngine;

public class UIManager : MonoBehaviour, IGameStateListener
{
    [Header("Panels")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject waveTransitionPanel;
    [SerializeField] private GameObject shopPanel;

    public void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.MENU:
                menuPanel.SetActive(true);
                gamePanel.SetActive(false);
                shopPanel.SetActive(false);
                waveTransitionPanel.SetActive(false);
                break;
            case GameState.GAME:
                menuPanel.SetActive(false);
                gamePanel.SetActive(true);
                shopPanel.SetActive(false);
                break;
            case GameState.WAVETRANSITION:
                gamePanel.SetActive(false);
                waveTransitionPanel.SetActive(true);
                break;
            case GameState.SHOP:
                gamePanel.SetActive(false);
                waveTransitionPanel.SetActive(false);
                shopPanel.SetActive(true);
                break;
        }
    }
}
