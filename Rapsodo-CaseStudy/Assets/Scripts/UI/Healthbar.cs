using UnityEngine;
using UnityEngine.UI;

namespace Rapsodo.MazeGame
{
    public class Healthbar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxHealth(int maxHealth)
        {
            slider.maxValue = maxHealth;
        }

        public void SetHealth(int health)
        {
            slider.value = health;
        }
    }

}

