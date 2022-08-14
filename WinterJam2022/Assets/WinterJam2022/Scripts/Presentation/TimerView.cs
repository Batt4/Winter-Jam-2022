using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WinterJam2022.Scripts.Presentation
{
    public class TimerView : MonoBehaviour
    {
        
        float time;
        Slider slider;
        bool isPlayingPlayer;
        [SerializeField] EventManager eventManager;
        [SerializeField] float basePlayerTime; // Mocked value.
        [SerializeField] float baseEnemyTime; // Mocked value.


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
                float baseTime = this.isPlayingPlayer? this.basePlayerTime: this.baseEnemyTime;
                slider.value = time / baseTime;
            }
        }

        public void UpdateTimers(float basePlayerTime, float baseEnemyTime) {
            this.basePlayerTime = basePlayerTime;
            this.baseEnemyTime = baseEnemyTime;
        }

        public void RestartTime(bool nextTurnIsForPlayer) {
            this.isPlayingPlayer = nextTurnIsForPlayer;
            this.time = this.isPlayingPlayer? this.basePlayerTime: this.baseEnemyTime;
            Debug.Log($"Timer was restarted to {time}");
        }

        public void CloseTime() {
            this.time = 0f;
        }

    }
}