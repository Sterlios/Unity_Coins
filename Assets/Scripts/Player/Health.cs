using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private float _maxValue = 1000f;
    private int _percentage = 100;

    public float DeltaHealth => 150f;

    public float Value { get; private set; }

    public event UnityAction<float> Changed;

    private void Awake()
    {
        Value = _maxValue;
    }

    public void OnTakeDamage()
    {
        float startValue = Value;
        Value = Value < DeltaHealth ? 0 : Value - DeltaHealth;
        Changed.Invoke(CalculatePercent());
    }

    public void OnHeal()
    {
        float startValue = Value;
        Value = _maxValue - Value < DeltaHealth ? _maxValue : Value + DeltaHealth;
        Changed.Invoke(CalculatePercent());
    }

    private float CalculatePercent() => Value / _maxValue * _percentage;
}
