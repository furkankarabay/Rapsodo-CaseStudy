using UnityEngine;

namespace Rapsodo.MazeGame
{
    public class Obstacle : MonoBehaviour
    {
        // Çeşitlendirilebilir;
        // Engellerin hızı, bekleme süresi gibi parametreleri bağlayabiliriz.

        [SerializeField] private int damageAmount;

        public void TriggerObstacle()
        {
            EventsSystem.OnDamagedByObstacle?.Invoke(damageAmount);
        }
    }

}
