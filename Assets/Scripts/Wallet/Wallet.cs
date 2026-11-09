using System.Collections.Generic;


public class Wallet
{
    private Dictionary<CurrencyType, ReactiveProperty<int>> _currencies = new();
    private const int MinCurrencyAmount = 0;
    private const int InitialCurrencyAmount = 0;
    public Wallet()
    {
        _currencies.Add(CurrencyType.Coin, new ReactiveProperty<int>(InitialCurrencyAmount));
        _currencies.Add(CurrencyType.Diamond, new ReactiveProperty<int>(InitialCurrencyAmount));
        _currencies.Add(CurrencyType.Energy, new ReactiveProperty<int>(InitialCurrencyAmount));
    }

    public bool TrySpend(CurrencyType type, int amount)
    {
        if (amount <= MinCurrencyAmount)
            return false;

        int currentAmount = _currencies[type].Value;

        if (currentAmount < amount)
            return false;

        _currencies[type].Value -= amount;
        return true;
    }

    public void Add(CurrencyType type, int amount)
    {
        if (amount <= MinCurrencyAmount)
            return;

        _currencies[type].Value += amount;
    }
    public ReactiveProperty<int> GetCurrency(CurrencyType type)
    {
        return _currencies[type];
    }
    public int GetAmount(CurrencyType type) => _currencies[type].Value;
}
