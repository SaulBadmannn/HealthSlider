using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _changeHealthStep = 10f;
    private float _maxHealth = 100f;
    private float _minHealth = 0f;

    public float Health => _health;

    public event UnityAction<float, float> HealthChanged;

    public void TryGetHeal()
    {
        if(_health < _maxHealth)
        {
            _health += _changeHealthStep;

            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }

            HealthChanged?.Invoke(_health, _maxHealth);
        } 
    }

    public void TryGetDamage()
    {
        if(_health > _minHealth)
        {
            _health -= _changeHealthStep;

            if (_health < _minHealth)
            {
                _health = _minHealth;
            }

            HealthChanged?.Invoke(_health, _maxHealth);
        }
    }
}
