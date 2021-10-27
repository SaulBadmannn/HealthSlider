using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangerSliderValue : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _changeStep = 0.3f;
    private float _waitStep = 0.02f;
    private bool _isValueChanging = false;
    private float _targetValue;

    public void SetValue(float value)
    {
        _slider.value = value;
    }

    public void IncreaseValue(float targetValue)
    {
        _targetValue = targetValue;

        if (_isValueChanging == false)
        {
            var changeValue = ChangingValue();
            StartCoroutine(changeValue);
        } 
    }

    public void DecreaseValue(float targetValue)
    {
        _targetValue = targetValue;

        if (_isValueChanging == false)
        {
            var changeValue = ChangingValue();
            StartCoroutine(changeValue);
        }       
    }

    private IEnumerator ChangingValue()
    {
        _isValueChanging = true;

        if (_slider.value < _targetValue)
        {
            while (_slider.value < _targetValue)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _changeStep);
                yield return new WaitForSeconds(_waitStep);
            }
        }
        else
        {
            while (_slider.value > _targetValue)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _changeStep);
                yield return new WaitForSeconds(_waitStep);
            }
        }

        _isValueChanging = false;
    }
}
