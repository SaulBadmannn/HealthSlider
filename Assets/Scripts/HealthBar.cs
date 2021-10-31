using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private float _changeStep = 0.3f;
    private float _waitStep = 0.02f;
    private bool _isValueChanging = false;
    private float _targetValue;

    private void OnEnable()
    {
        _player.ChangingHealth += ChangeValue;
    }

    private void OnDisable()
    {
        _player.ChangingHealth -= ChangeValue;
    }

    private void Start()
    {
        _slider.value = _player.Health;
    }

    public void ChangeValue(float targetValue)
    {
        _targetValue = targetValue;

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
