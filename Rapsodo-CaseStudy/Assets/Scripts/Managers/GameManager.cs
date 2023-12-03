using UnityEngine;

namespace Rapsodo.MazeGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameObject Player;

        [SerializeField] private CountdownTimer countdownTimer;
        [SerializeField] private Transform startPoint;

        private GameStatus gameStatus = GameStatus.BeforeStart;

        public static bool hasGameStarted = false;
        public static bool hasGameFinished = false;
        public static bool isWon = false;


        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

            countdownTimer.StartCountdownTimer(gameStatus);
        }

        private void OnEnable()
        {
            EventsSystem.OnCountdownIsOver += UpdateGameStatus;
            EventsSystem.OnGameFinished += OnGameFinished;

        }

        private void OnDisable()
        {
            EventsSystem.OnCountdownIsOver -= UpdateGameStatus;
            EventsSystem.OnGameFinished -= OnGameFinished;

        }

        private void OnGameFinished(bool won)
        {
            isWon = won;

            UpdateGameStatus();
        }

        private void UpdateGameStatus()
        {
            switch (gameStatus)
            {
                case GameStatus.BeforeStart:
                    EventsSystem.OnGameStarted?.Invoke();
                    Player.transform.position = startPoint.position;
                    hasGameFinished = false;
                    hasGameStarted = true;

                    gameStatus = GameStatus.InGame;

                    countdownTimer.StartCountdownTimer(gameStatus);

                    break;

                case GameStatus.InGame:


                    gameStatus = GameStatus.AfterGame;
                    countdownTimer.StartCountdownTimer(gameStatus, isWon);
                    hasGameFinished = true;

                    break;
                case GameStatus.AfterGame:

                    hasGameFinished = false;

                    gameStatus = GameStatus.BeforeStart;
                    countdownTimer.StartCountdownTimer(gameStatus);
                    break;

            }
        }
    }

    public enum GameStatus
    {
        BeforeStart,
        InGame,
        AfterGame
    }

}
