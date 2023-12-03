using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float elapsedTime;

    private bool isActivated = false;

    private void OnEnable()
    {
        EventsSystem.OnGameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        EventsSystem.OnGameStarted -= OnGameStarted;
    }

    private void OnGameStarted()
    {
        Debug.Log("Bum");
        isActivated = true;
    }
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

        if(isActivated)
        {
            elapsedTime = 0;
        }
    }
}
