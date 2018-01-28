using UnityEngine;
using System.Collections;

namespace FallingSloth.GGJ18
{
    public class HitEffect : MonoBehaviour
    {
        public float lifetime = 2f;

        void Start()
        {
            Destroy(gameObject, lifetime);
        }
    }
}