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

        Animator animator;

        bool isDead = false;

        void Start()
        {
            animator = GetComponent<Animator>();
        }
        
        void Update()
        {
            if (!isDead)
            {
                Move();
            }
        }

        void Move()
        {
            if (transform.position.x >= maxPosition.position.x)
                return;
            else
                transform.Translate(Time.deltaTime * speed, 0f, 0f);
        }

        public void Hit(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                isDead = true;
                animator.SetTrigger("Died");
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}