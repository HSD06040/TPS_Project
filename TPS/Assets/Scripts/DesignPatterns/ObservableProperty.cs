using System;
using UnityEngine;

namespace DesignPattern
{
    public class ObservableProperty<T>
    {
        [SerializeField] private T _value;
        public T Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value)) return;
                _value = value;
                Notify();
            }
        }
        private Action<T> _onValueChanged;

        public ObservableProperty(T value = default)
        {
            _value = value;
        }

        public void Subscribe(Action<T> action)
        {
            _onValueChanged += action;
        }

        public void Unsubscribe(Action<T> action)
        {
            _onValueChanged -= action;
        }

        public void UnsbscribeAll()
        {
            foreach (Action<T> action in _onValueChanged.GetInvocationList())
            {
                _onValueChanged -= action;
            }
        }

        private void Notify()
        {
            _onValueChanged?.Invoke(Value);
        }
    }
}
