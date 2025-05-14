using System;

public class ObservableProperty<T>
{
    private T _value;
    public T Value { get => _value; set { if(!_value.Equals(value)) _value = value; onValueChanged?.Invoke(Value); } }

    private Action<T> onValueChanged;

    public ObservableProperty(T value = default)
    {
        _value = value;
    }

    public void Subscribe(Action<T> action) => onValueChanged += action;

    public void Unsubscribe(Action<T> action) => onValueChanged -= action;

    public void UnSubscribeAll()
    {
        foreach (Action<T> action in onValueChanged.GetInvocationList())
        {
            onValueChanged -= action;
        }
    }
}
