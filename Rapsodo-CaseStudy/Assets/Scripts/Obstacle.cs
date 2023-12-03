using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public void TriggerObstacle()
    {
        EventsSystem.OnDamagedByObstacle?.Invoke(2);
    }
}
