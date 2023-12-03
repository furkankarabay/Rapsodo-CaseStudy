using UnityEngine;

namespace Rapsodo.MazeGame
{
    public class Powerup : MonoBehaviour
    {
        public PowerupEffect powerupEffect;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                powerupEffect.Apply();
            }
        }
    }

}
