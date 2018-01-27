using UnityEngine;
using System.Collections;

using FallingSloth.UI;

namespace FallingSloth.GGJ18
{
    public class Base : MonoBehaviour
    {
        public HealthBar healthBar;

        public int maxHealth = 999;

        [HideInInspector]
        public int currentHealth = 999;

        void Awake()
        {
            Reset();
        }

        void Reset()
        {
            healthBar.maxValue = maxHealth;
            healthBar.currentValue = maxHealth;

            currentHealth = maxHealth;
        }
    }
}