using System;

namespace Rapsodo.MazeGame
{
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
        public static Action<bool> OnGameFinished;

        #endregion
    }

}
