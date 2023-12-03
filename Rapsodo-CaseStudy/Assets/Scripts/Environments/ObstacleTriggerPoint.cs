using UnityEngine;

namespace Rapsodo.MazeGame
{
    public class ObstacleTriggerPoint : MonoBehaviour
    {
        [SerializeField] private Obstacle obstacle;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                obstacle.TriggerObstacle();
            }
        }
    }

}
