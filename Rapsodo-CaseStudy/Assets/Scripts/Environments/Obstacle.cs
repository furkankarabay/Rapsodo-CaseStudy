using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Çeşitlendirilebilir;
    // Engellerin hızı, bekleme süresi gibi parametreleri bağlayabiliriz.

    [SerializeField] private int damageAmount;

    public void TriggerObstacle()
    {
        EventsSystem.OnDamagedByObstacle?.Invoke(damageAmount);
    }
}
