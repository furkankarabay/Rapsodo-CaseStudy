using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private GameObject upsideDownCamera;
    [SerializeField] private GameObject tpsCamera;

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
        upsideDownCamera.SetActive(false);
        tpsCamera.SetActive(true);

    }
}
