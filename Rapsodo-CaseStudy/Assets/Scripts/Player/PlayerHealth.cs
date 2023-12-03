using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public Healthbar healthbar;
    private void OnEnable()
    {
        EventsSystem.OnGameStarted += OnGameStarted;
        EventsSystem.OnDamagedByObstacle += DecreaseHealth;
        EventsSystem.OnPowerupHealthEffect += ApplyPowerupEffect;
    }

    private void OnDisable()
    {
        EventsSystem.OnGameStarted -= OnGameStarted;
        EventsSystem.OnDamagedByObstacle -= DecreaseHealth;
        EventsSystem.OnPowerupHealthEffect -= ApplyPowerupEffect;
    }
    private void OnGameStarted()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(currentHealth);
    }

    private void ApplyPowerupEffect(int amount)
    {
        IncreaseHealth(amount);
        CheckHealthLevel();
    }

    private void IncreaseHealth(int amount)
    {
        if (currentHealth + amount > maxHealth)
            return;

        currentHealth += amount;
        healthbar.SetHealth(currentHealth);
        CheckHealthLevel();
    }

    private void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        healthbar.SetHealth(currentHealth);
        CheckHealthLevel();
    }

    private void CheckHealthLevel()
    {
        if(currentHealth <= 0)
        {
            EventsSystem.OnGameFinished?.Invoke(false);
        }
    }
}
