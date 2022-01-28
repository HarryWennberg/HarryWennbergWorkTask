using System;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class TimePickUp : Pickup
    {
        [Header("Parameters")]
        [Tooltip("How strong the slow is")]
        public float slowAmount;

        [Tooltip("How long the slow is")]
        public float slowTime;

        public void SlowTimer()
        {
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            Time.timeScale += (1f / slowTime) * Time.unscaledDeltaTime;
        }

        protected override void OnPicked(PlayerCharacterController player)
        {
            
            if(player)
            {
                //put time slow here
                DoSlowmotion();
                PlayPickupFeedback();
                Destroy(gameObject);
            }
        }

        private void DoSlowmotion()
        {
            Time.timeScale = slowAmount;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }

}
