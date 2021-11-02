using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private float _changeStep;

    private float _waitStep = 0.02f;
    private bool _isValueChanging = false;
    private float _targetValue;

    private void OnEnable()
    {
        _player.HealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeValue;
    }

    private void Start()
    {
        _slider.value = _player.Health;
    }

    public void ChangeValue(float targetValue, float maxValue)
    {
        _targetValue = targetValue;
        _slider.maxValue = maxValue;

        if (_isValueChanging == false)
        {
            StartCoroutine(ChangingValue());
        } 
    }

    private IEnumerator ChangingValue()
    {
        _isValueChanging = true;

            while (_slider.value < _targetValue || _slider.value > _targetValue)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _changeStep);
                yield return new WaitForSeconds(_waitStep);
            }

        _isValueChanging = false;
    }
}
