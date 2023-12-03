using TMPro;
using UnityEngine;

namespace Rapsodo.MazeGame
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private TextMeshProUGUI countdownTimerText;
        [SerializeField] private GameObject parent;
        [SerializeField] private GameObject hint;
        [SerializeField] private TextMeshProUGUI messageText;


        [SerializeField] private float remainingTime;

        private bool isActivated = false;


        private void Update()
        {
            if (!isActivated)
                return;

            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime <= 0)
            {
                isActivated = false;
                remainingTime = 0;
                parent.SetActive(false);
                hint.SetActive(false);
                EventsSystem.OnCountdownIsOver?.Invoke();
            }

            int seconds = Mathf.FloorToInt(remainingTime % 60);
            countdownTimerText.text = seconds.ToString();
        }

        public void SetRemainingTime(int remainingTime)
        {
            this.remainingTime = remainingTime;
        }

        public void StartCountdownTimer(GameStatus status, bool isWon = false)
        {

            if (status == GameStatus.BeforeStart)
            {
                SetRemainingTime(5);
                hint.SetActive(true);
                parent.SetActive(true);

                messageText.text = "The game begins...";

            }
            else if (status == GameStatus.InGame)
            {
                timer.ToggleTimer();
            }
            else if (status == GameStatus.AfterGame)
            {
                timer.ToggleTimer();

                hint.SetActive(false);
                parent.SetActive(true);

                SetRemainingTime(5);

                if (isWon)
                {
                    messageText.text = "Congratulations...";
                }
                else
                {
                    messageText.text = "You dead...";

                }

            }

            isActivated = true;
        }
    }

}
