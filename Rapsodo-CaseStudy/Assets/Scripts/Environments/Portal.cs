using UnityEngine;

namespace Rapsodo.MazeGame
{
    public class Portal : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                EventsSystem.OnGameFinished?.Invoke(true);
            }
        }
    }

}
