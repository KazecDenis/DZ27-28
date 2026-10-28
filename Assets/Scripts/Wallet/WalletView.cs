using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CurrencyIconData
{
    public CurrencyType Type;
    public Sprite Icon;
}

public class WalletView : MonoBehaviour
{
    [SerializeField] private CurrencyItemView _currencyItemPrefab;
    [SerializeField] private Transform _content;
    [SerializeField] private CurrencyIconData[] _currencyIcons;
    private Wallet _wallet;
    private Dictionary<CurrencyType, CurrencyItemView> _items = new();

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
        {
            CurrencyItemView item = Instantiate(_currencyItemPrefab, _content);

            item.SetAmount(wallet.GetAmount(type));
            item.SetIcon(GetIcon(type));

            _items.Add(type, item);

            _wallet.CurrencyChanged += OnCurrencyChanged;
        }
    }


    private void OnCurrencyChanged(CurrencyType type, int amount)
    {
        _items[type].SetAmount(amount);
    }

    private void OnDestroy()
    {
        if (_wallet != null)
            _wallet.CurrencyChanged -= OnCurrencyChanged;
    }

    private Sprite GetIcon(CurrencyType type)
    {
        foreach (CurrencyIconData icon in _currencyIcons)
        {
            if (icon.Type == type)
                return icon.Icon;
        }
            
        return null;
    }
}
