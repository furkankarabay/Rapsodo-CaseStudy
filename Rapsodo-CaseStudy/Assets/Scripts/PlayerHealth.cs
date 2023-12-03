using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public Healthbar healthbar;
    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        EventsSystem.OnDamagedByObstacle += DecreaseHealth;
        EventsSystem.OnPowerupHealthEffect += ApplyPowerupEffect;
    }

    private void OnDisable()
    {
        EventsSystem.OnDamagedByObstacle -= DecreaseHealth;
        EventsSystem.OnPowerupHealthEffect -= ApplyPowerupEffect;
    }

    private void ApplyPowerupEffect(int amount)
    {
        IncreaseHealth(amount);
        CheckHealthLevel();
    }

    private void IncreaseHealth(int amount)
    {
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
        if(currentHealth < 0)
        {

        }
    }
}
