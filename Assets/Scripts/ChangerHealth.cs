using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangerHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _targetValue;
    private float _changeValueStep = 10f;
    private float _changeStep = 0.3f;
    private float _waitStep = 0.02f;
    private bool _isHealthChanging = false;
    private float _playerHealth = 50f;
    private float _maxValueSlider = 100f;
    private float _minValueSlider = 0f;

    private void Start()
    {
        _slider.value = _playerHealth;
    }

    public void GetHeal()
    {
        if(_targetValue < _maxValueSlider)
        {
            _targetValue = _playerHealth + _changeValueStep;
        }
        
        _playerHealth = _targetValue;

        if (_isHealthChanging == false)
        {
            var changeHealth = ChangingHealth();
            StartCoroutine(changeHealth);
        }
        
    }

    public void GetDamage()
    {
        if(_targetValue > _minValueSlider)
        {
            _targetValue = _playerHealth - _changeValueStep;
        }

        _playerHealth = _targetValue;

        if (_isHealthChanging == false)
        {
            var changeHealth = ChangingHealth();
            StartCoroutine(changeHealth);
        }       
    }

    private IEnumerator ChangingHealth()
    {
        _isHealthChanging = true;

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

        _isHealthChanging = false;
    }
}
