using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private float _targetValue;
    private float _changeValueStep = 10f;
    private float _changeStep = 0.3f;
    private float _waitStep = 0.02f;

    private void Start()
    {
        _slider.value = 50f;
    }

    public void GetHeal()
    {
        var heal = IsHealing();

        StartCoroutine(heal);
    }

    public void GetDamage()
    {
        var dealtDamage = IsDealtDamage();

        StartCoroutine(dealtDamage);
    }

    private IEnumerator IsHealing()
    {
        _targetValue = _slider.value + _changeValueStep;

        while (_slider.value < _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _changeStep);
            yield return new WaitForSeconds(_waitStep);
        }
    }

    private IEnumerator IsDealtDamage()
    {
        _targetValue = _slider.value - _changeValueStep;

        while (_slider.value > _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _changeStep);
            yield return new WaitForSeconds(_waitStep);
        }
    }
}
