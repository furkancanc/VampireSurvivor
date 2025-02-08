using System.Collections.Generic;
using UnityEngine;

public class StatContainerManager : MonoBehaviour
{
    public static StatContainerManager instance;

    [Header("Elements")]
    [SerializeField] private StatContainer statContainer;

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

    private void GenerateContainers(Dictionary<Stat, float> statDictionary, Transform parent)
    {
        List<StatContainer> statContainers = new List<StatContainer>();

        foreach (KeyValuePair<Stat, float> kvp in statDictionary)
        {
            StatContainer containerInstance = Instantiate(statContainer, parent);
            statContainers.Add(containerInstance);

            Sprite statIcon = ResourcesManager.GetStatIcon(kvp.Key);
            string statName = Enums.FormatStatName(kvp.Key);
            string statValue = kvp.Value.ToString("F2");

            containerInstance.Configure(statIcon, statName, statValue);
        }

        //ResizeTexts(statContainers);
        LeanTween.delayedCall(Time.deltaTime * 2, () => ResizeTexts(statContainers));
    }

    private void ResizeTexts(List<StatContainer> statContainers)
    {
        float minFontSize = 5000;

        for (int i = 0; i < statContainers.Count; ++i)
        {
            StatContainer statContainer = statContainers[i];
            float fontSize = statContainer.GetFontSize();

            if (fontSize < minFontSize)
            {
                minFontSize = fontSize;
            }
        }

        for (int i = 0; i < statContainers.Count; ++i)
        {
            statContainers[i].SetFontSize(minFontSize);
        }
    }

    public static void GenerateStatContainers(Dictionary<Stat, float> statDictionary, Transform parent)
    {
        instance.GenerateContainers(statDictionary, parent);
    }
}
