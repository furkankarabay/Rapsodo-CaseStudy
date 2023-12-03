using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsSystem
{
    #region Obstacle Events

    public static Action<int> OnDamagedByObstacle;

    #endregion

    #region Powerup Effect

    public static Action<int> OnPowerupHealthEffect;

    #endregion

    #region Game Flow

    public static Action OnCountdownIsOver;
    public static Action OnGameStarted;
    public static Action OnGameFinished;

    #endregion
}
