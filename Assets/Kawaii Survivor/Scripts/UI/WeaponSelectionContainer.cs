using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionContainer : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI nameText;

    [field: SerializeField] public Button Button { get; private set; }

    [Header("Color")]
    [SerializeField] private Image[] levelDependentImages;
    public void Configure(Sprite sprite, string name, int level)
    {
        icon.sprite = sprite;
        nameText.text = name;

        Color imageColor = ColorHolder.GetColor(level);
        Debug.Log(imageColor);

        foreach (Image image in levelDependentImages)
        {
            image.color = imageColor;
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
