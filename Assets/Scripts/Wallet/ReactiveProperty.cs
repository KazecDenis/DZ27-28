using System;

public class ReactiveProperty<T> where T : IEquatable<T>
{
    public event Action<T> Changed;
    private T _value;

    public ReactiveProperty() => _value = default;
    public ReactiveProperty(T initialize)
    {
        _value = initialize;
    }
    public T Value
    {
        get => _value;
        set
        {
            
            T oldValue = _value;
            _value = value;

            if (oldValue.Equals(_value) == false)
                Changed?.Invoke(_value);
        }
    }
}

