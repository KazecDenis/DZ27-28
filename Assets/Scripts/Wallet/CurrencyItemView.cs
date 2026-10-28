using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _amountText;

    public void SetAmount(int amount)
    {
        _amountText.text = amount.ToString();
    }

    public void SetIcon(Sprite icon)
    {
        _icon.sprite = icon;
    }
}
