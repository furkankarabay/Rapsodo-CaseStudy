using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Çeþitlendirilebilir;
    // Engellerin hýzý, bekleme süresi gibi parametreleri baðlayabiliriz.

    [SerializeField] private int damageAmount;

    public void TriggerObstacle()
    {
        EventsSystem.OnDamagedByObstacle?.Invoke(damageAmount);
    }
}
