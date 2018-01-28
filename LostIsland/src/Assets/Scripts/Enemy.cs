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

        public HitEffect hitEffectPrefab;

        public int damagePerSecond = 2;

        Animator animator;

        bool isDead = false;

        bool isAtEnd = false;

        public bool dieAtEnd = false;

        void Start()
        {
            animator = GetComponent<Animator>();
        }
        
        void Update()
        {
            if (!isDead && !isAtEnd)
            {
                Move();
            }
        }

        void Move()
        {
            if (transform.position.x >= maxPosition.position.x)
            {
                isAtEnd = true;
                StartCoroutine(DamageBase());
            }
            else
            {
                transform.Translate(Time.deltaTime * speed, 0f, 0f);
            }
        }

        public void Hit(int damage, Vector2 hitPosition)
        {
            Instantiate(hitEffectPrefab, new Vector3(hitPosition.x, hitPosition.y, hitEffectPrefab.transform.position.z), Quaternion.identity);

            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                isDead = true;
                animator.SetTrigger("Died");
            }
        }

        IEnumerator DamageBase()
        {
            if (dieAtEnd)
            {
                Base.Instance.Hit(damagePerSecond);
                isDead = true;
                animator.SetTrigger("Died");
                yield break;
            }
            while (!isDead && isAtEnd)
            {
                Base.Instance.Hit(damagePerSecond);
                yield return new WaitForSeconds(1f);
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}