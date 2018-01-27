using UnityEngine;
using System.Collections;

using FallingSloth.UI;

namespace FallingSloth.GGJ18
{
    public class Enemy : MonoBehaviour
    {
        [HideInInspector]
        public HealthBar healthBar;

        [HideInInspector]
        public Transform maxPosition;

        public int maxHealth;
        
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

        public float speed;

        Camera cam;

        [Range(0.0f, 1.0f)]
        public float healthBarAnchorY;

        void Start()
        {
            cam = Camera.main;
        }

        void OnDestroy()
        {
            Destroy(healthBar.gameObject);
        }
        
        void Update()
        {
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                return;
            }

            Move();

            MoveHealthBar();
        }

        void Move()
        {
            if (transform.position.x >= maxPosition.position.x)
                return;
            else
                transform.Translate(Time.deltaTime * speed, 0f, 0f);
        }

        void MoveHealthBar()
        {
            float maxX = cam.orthographicSize * 2f * cam.aspect;
            float currentX = transform.position.x + (maxX / 2f);
            healthBar.rectTransform.anchorMin = new Vector2(currentX / maxX, healthBarAnchorY);
            healthBar.rectTransform.anchorMax = new Vector2(currentX / maxX, healthBarAnchorY);
        }
    }
}