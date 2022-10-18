using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fillImage;
    private Coroutine _changeJob = null;
    private float _step = 20f;

    private void OnEnable()
    {
        _health.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnChanged;
    }

    public void OnChanged(float targetPercent)
    {
        if (_changeJob != null)
        {
            StopCoroutine(_changeJob);
        }

        _changeJob = StartCoroutine(Change(targetPercent));
    }

    private IEnumerator Change(float targetPercent)
    {
        while (_slider.value != targetPercent)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetPercent * _slider.maxValue, _step * Time.deltaTime);
            _fillImage.color = GetFillColor(targetPercent);
            yield return null;
        }
    }

    private Vector4 GetFillColor(float value)
    {
        float halfHelth = 0.5f;
        value = Mathf.Clamp(value, 0, 1);

        if (value < halfHelth)
        {
            return Vector4.Lerp(Color.red, Color.yellow, value * 2);
        }
        else
        {
            return Vector4.Lerp(Color.yellow, Color.green, value * 2 - 1);
        }
    }
}
