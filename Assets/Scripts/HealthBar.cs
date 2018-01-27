using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FallingSloth.UI
{
    public class HealthBar : MonoBehaviour
    {
        public RectTransform rectTransform { get { return transform as RectTransform; } }

        RectTransform bar;
        Text text;
        
        public float maxValue;
        
        public float currentValue
        {
            get
            {
                return maxValue * bar.anchorMax.x;
            }
            set
            {
                bar.anchorMax = new Vector2( (value / maxValue), 1f);
                text.text = value + "/" + maxValue;
            }
        }
        
        void Awake()
        {
            bar = transform.Find("Bar") as RectTransform;
            text = transform.Find("Text").GetComponent<Text>();
        }
    }
}