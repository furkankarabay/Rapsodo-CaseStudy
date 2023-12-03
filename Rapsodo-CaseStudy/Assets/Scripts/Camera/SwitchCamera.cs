using UnityEngine;

namespace Rapsodo.MazeGame
{
    public class SwitchCamera : MonoBehaviour
    {
        [SerializeField] private GameObject upsideDownCamera;
        [SerializeField] private GameObject tpsCamera;

        private void OnEnable()
        {
            EventsSystem.OnGameStarted += OnGameStarted;
            EventsSystem.OnGameFinished += OnGameFinished;
        }

        private void OnDisable()
        {
            EventsSystem.OnGameStarted -= OnGameStarted;
            EventsSystem.OnGameFinished -= OnGameFinished;

        }

        private void OnGameStarted()
        {
            upsideDownCamera.SetActive(false);
            tpsCamera.SetActive(true);
        }

        private void OnGameFinished(bool isWon)
        {
            upsideDownCamera.SetActive(true);
            tpsCamera.SetActive(false);
        }
    }

}
