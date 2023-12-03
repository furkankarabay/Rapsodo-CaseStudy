using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownTimerText;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject hint;


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
        else if(remainingTime < 0)
        {
            remainingTime = 0;
            isActivated = false;
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

    public void StartCountdownTimer()
    {
        isActivated = true;
    }
}
