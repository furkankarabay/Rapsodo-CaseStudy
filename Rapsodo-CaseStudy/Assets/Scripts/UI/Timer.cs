using TMPro;
using UnityEngine;

namespace Rapsodo.MazeGame
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        private float elapsedTime;

        private bool isActivated = false;

        private void Update()
        {
            if (!isActivated)
                return;

            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public void ToggleTimer()
        {
            isActivated = !isActivated;
            gameObject.SetActive(isActivated);

            if (isActivated)
            {
                elapsedTime = 0;
            }
        }
    }

}

