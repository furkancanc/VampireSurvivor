using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionContainer : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI nameText;

    [Header("Stats")]
    [SerializeField] private Transform statContainersParent;
    [SerializeField] private StatContainer statContainerPrefab;
    [SerializeField] private Sprite statIcon;
    [field: SerializeField] public Button Button { get; private set; }

    [Header("Color")]
    [SerializeField] private Image[] levelDependentImages;
    public void Configure(Sprite sprite, string name, int level, WeaponDataSO weaponData)
    {
        icon.sprite = sprite;
        nameText.text = name;

        Color imageColor = ColorHolder.GetColor(level);
        foreach (Image image in levelDependentImages)
        {
            image.color = imageColor;
        }

        ConfigureStatContainers(weaponData);
    }

    private void ConfigureStatContainers(WeaponDataSO weaponData)
    {
        foreach (KeyValuePair<Stat, float> kvp in weaponData.BaseStats)
        {
            StatContainer containerInstance = Instantiate(statContainerPrefab, statContainersParent);

            Sprite statIcon = ResourcesManager.GetStatIcon(kvp.Key);
            string statName = Enums.FormatStatName(kvp.Key);
            string statValue = kvp.Value.ToString();

            containerInstance.Configure(statIcon, statName, statValue);
        }
    }

    public void Select()
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector3.one * 1.057f, .3f).setEase(LeanTweenType.easeInOutSine);
    }

    public void Deselect()
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector3.one, .3f);
    }
}
