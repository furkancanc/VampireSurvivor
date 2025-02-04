using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WaveCompletedCallback()
    {
        if (Player.instance.HasLeveledUp())
        {
            Debug.Log("Show Wave Transition Panel");
        }
        else
        {
            Debug.Log("Display shop!");
        }
    }
}
