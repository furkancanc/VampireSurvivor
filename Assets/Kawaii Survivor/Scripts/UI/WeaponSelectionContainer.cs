using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionContainer : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI nameText;

    public void Configure(Sprite sprite, string name)
    {
        icon.sprite = sprite;
        nameText.text = name;
    }
}
