using UnityEngine;

namespace Rapsodo.MazeGame
{
    public class Obstacle : MonoBehaviour
    {
        // Çeþitlendirilebilir;
        // Engellerin hýzý, bekleme süresi gibi parametreleri baðlayabiliriz.

        [SerializeField] private int damageAmount;

        public void TriggerObstacle()
        {
            EventsSystem.OnDamagedByObstacle?.Invoke(damageAmount);
        }
    }

}
