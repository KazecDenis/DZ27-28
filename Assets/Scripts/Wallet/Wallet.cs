using System;
using System.Collections.Generic;


public class Wallet
{
    public event Action<CurrencyType, int> CurrencyChanged;
    private Dictionary<CurrencyType, int> _currencies = new();
    private const int MinCurrencyAmount = 0;
    private const int InitialCurrencyAmount = 0;
    public Wallet()
    {
        _currencies.Add(CurrencyType.Coin, InitialCurrencyAmount);
        _currencies.Add(CurrencyType.Diamond, InitialCurrencyAmount);
        _currencies.Add(CurrencyType.Energy, InitialCurrencyAmount);
    }

    public bool TrySpend(CurrencyType type, int amount)
    {
        if (amount <= MinCurrencyAmount)
            return false;

        int currentAmount = _currencies[type];

        if (currentAmount < amount)
            return false;

        _currencies[type] -= amount;
        CurrencyChanged?.Invoke(type, _currencies[type]);
        return true;
    }

    public void Add(CurrencyType type, int amount)
    {
        if (amount <= MinCurrencyAmount)
            return;

        _currencies[type] += amount;
        CurrencyChanged?.Invoke(type, _currencies[type]);
    }
        
    public int GetAmount(CurrencyType type) => _currencies[type];
}
