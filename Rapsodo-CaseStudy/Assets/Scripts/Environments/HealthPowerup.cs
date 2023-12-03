using UnityEngine;


namespace Rapsodo.MazeGame
{
    [CreateAssetMenu(menuName = "Powerups/HealthBuff")]
    public class HealthPowerup : PowerupEffect
    {
        public int amount;
        public override void Apply()
        {
            EventsSystem.OnPowerupHealthEffect?.Invoke(amount);
        }
    }
}

