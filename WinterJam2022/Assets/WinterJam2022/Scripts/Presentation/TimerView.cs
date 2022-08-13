using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WinterJam2022.Scripts.Presentation
{
    public class TimerView : MonoBehaviour
    {
        
        Slider slider;
        [SerializeField] EventManager eventManager;

        private float time;
        private float baseTime = 2f; // Mocked value.

        void Start() {
            slider = GetComponent<Slider>();
        }

        void FixedUpdate() {
            if (time > 0f) {
                time -= Time.deltaTime;
                if (time <= 0) {
                    time = 0f;
                    eventManager.Timeout();
                }
                slider.value = time / baseTime;
            }
        }

        public void RestartTime() {
            this.time = this.baseTime;
            Debug.Log($"Timer was restarted to {time}");
        }

    }
}