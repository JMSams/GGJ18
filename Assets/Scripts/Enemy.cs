using UnityEngine;
using System.Collections;

using FallingSloth.UI;

namespace FallingSloth.GGJ18
{
    public class Enemy : MonoBehaviour
    {
        [HideInInspector]
        public Transform maxPosition;

        public int maxHealth;

        [HideInInspector]
        public int currentHealth;

        public float speed;
        
        void Update()
        {
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                return;
            }

            Move();
        }

        void Move()
        {
            if (transform.position.x >= maxPosition.position.x)
                return;
            else
                transform.Translate(Time.deltaTime * speed, 0f, 0f);
        }
    }
}