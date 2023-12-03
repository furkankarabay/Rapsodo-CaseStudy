using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthPowerup : PowerupEffect
{
    public int amount;
    public override void Apply()
    {
        EventsSystem.OnPowerupHealthEffect?.Invoke(amount);
    }
}
