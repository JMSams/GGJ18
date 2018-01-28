using UnityEngine;
using System.Collections;

using FallingSloth.UI;

namespace FallingSloth.GGJ18
{
    public class Base : SingletonBehaviour<Base>
    {
        public HealthBar healthBar;

        public int maxHealth = 999;
        
        public int currentHealth
        {
            get
            {
                return Mathf.RoundToInt(healthBar.currentValue);
            }
            set
            {
                healthBar.currentValue = value;
            }
        }

        protected override void Awake()
        {
            base.Awake();

            Reset();
        }

        void Reset()
        {
            healthBar.maxValue = maxHealth;
            healthBar.currentValue = maxHealth;

            currentHealth = maxHealth;
        }

        public void Hit(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                GameOver();
            }
        }

        void GameOver()
        {
            SceneManager.Instance.LoadScene(2);
        }
    }
}