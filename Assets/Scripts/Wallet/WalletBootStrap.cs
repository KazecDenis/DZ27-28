using UnityEngine;

public class WalletBootStrap : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    private Wallet _wallet; 
    private const int _minManyValue = 1;
    private const int _mediumManyValue = 5;
    private const int _maxManyValue = 10;

    private void Start()
    {
        _wallet = new Wallet();
        _walletView.Initialize(_wallet);

        _wallet.Add(CurrencyType.Coin, 100);
        _wallet.Add(CurrencyType.Diamond, 50);
        _wallet.Add(CurrencyType.Energy, 10);

        ShowAddInfo(CurrencyType.Coin, _maxManyValue, 1); 
        ShowRemoveInfo(CurrencyType.Coin, _maxManyValue, "Q");

        ShowAddInfo(CurrencyType.Diamond, _mediumManyValue, 2);
        ShowRemoveInfo(CurrencyType.Diamond, _mediumManyValue, "W");

        ShowAddInfo(CurrencyType.Energy, _minManyValue, 3);
        ShowRemoveInfo(CurrencyType.Energy, _minManyValue, "E");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _wallet.Add(CurrencyType.Coin, _maxManyValue);

        if (Input.GetKeyDown(KeyCode.Q))
            _wallet.TrySpend(CurrencyType.Coin, _maxManyValue);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _wallet.Add(CurrencyType.Diamond, _mediumManyValue);

        if (Input.GetKeyDown(KeyCode.W))
            _wallet.TrySpend(CurrencyType.Diamond, _mediumManyValue);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            _wallet.Add(CurrencyType.Energy, _minManyValue);

        if (Input.GetKeyDown(KeyCode.E))
            _wallet.TrySpend(CurrencyType.Energy, _minManyValue);

    }

    private void ShowAddInfo (CurrencyType type, int value, int keyCommand)
    {
        Debug.Log($"что бы добавить {type}: {value} нажмите {keyCommand}");
    }

    private void ShowRemoveInfo (CurrencyType type, int value, string keyCommand)
    {
        Debug.Log($"что бы потратить {type}: {value} нажмите {keyCommand}");
    }
}

