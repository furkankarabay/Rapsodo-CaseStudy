using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private CountdownTimer countdownTimer;

    private GameStatus gameStatus = GameStatus.BeforeStart;

    public static bool hasGameStarted = false;

    private void Awake()
    {
        if(!Instance)
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
        countdownTimer.StartCountdownTimer();
    }

    private void OnEnable()
    {
        EventsSystem.OnCountdownIsOver += UpdateGameStatus;
    }

    private void OnDisable()
    {
        EventsSystem.OnCountdownIsOver -= UpdateGameStatus;
    }

    private void UpdateGameStatus()
    {
        switch (gameStatus) 
        {
            case GameStatus.BeforeStart:
                EventsSystem.OnGameStarted?.Invoke();
                hasGameStarted = true;
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
