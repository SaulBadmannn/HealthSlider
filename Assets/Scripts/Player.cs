using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private ChangerSliderValue _changerSliderValue;

    private float _changeHealthStep = 10f;
    private float _maxHealth = 100f;
    private float _minHealth = 0f;

    private void Start()
    {
        _changerSliderValue.SetValue(_health);
    }

    public void TryGetHeal()
    {
        if(_health < _maxHealth)
        {
            _health += _changeHealthStep;
            _changerSliderValue.IncreaseValue(_health);
        } 
    }

    public void TryGetDamage()
    {
        if(_health > _minHealth)
        {
            _health -= _changeHealthStep;
            _changerSliderValue.DecreaseValue(_health);
        }
    }
}
