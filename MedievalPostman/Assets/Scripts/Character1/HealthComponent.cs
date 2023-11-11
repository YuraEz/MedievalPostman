using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    [Space]
    [SerializeField] private UIProgressBar healthBar;

    [Space]
    [ReadOnly, SerializeField] private float health;

    public Action<float> onDamage;
    public Action onDie;

    public static HealthComponent instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
        //healthBar.SetMaxValue(health);
    }

    public void Damage(float damage)
    {
        health -= damage;
        onDamage?.Invoke(health);
        UIProgressBar.Instance.SetValue(health);
        //healthBar.SetValue(health);

        if (health <= 0)
        {
            onDie?.Invoke();
        }
    }
}
