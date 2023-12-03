using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // �e�itlendirilebilir;
    // Engellerin h�z�, bekleme s�resi gibi parametreleri ba�layabiliriz.

    [SerializeField] private int damageAmount;

    public void TriggerObstacle()
    {
        EventsSystem.OnDamagedByObstacle?.Invoke(damageAmount);
    }
}
