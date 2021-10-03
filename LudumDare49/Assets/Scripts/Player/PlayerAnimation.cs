using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class PlayerAnimation : MonoBehaviour
    {
        public Animator animator;
        public PlayerMovement playerMovement;
        public float scaleX = -0.175f;
        public float offsetX = 0.15f;

        private const string WalkingBool = "walking";
        private const string RunningBool = "running";
        private const string JumpingBool = "jumping";
        private const string DieTrigger = "die";

        public void OnDeath()
        {
            animator.SetTrigger(DieTrigger);
        }

        private void Update()
        {
            animator.SetBool(WalkingBool, playerMovement.IsWalking());
            animator.SetBool(RunningBool, playerMovement.IsRunning());
            animator.SetBool(JumpingBool, playerMovement.IsJumping());
        }

        public void SetFlipped(bool flipped)
        {
            animator.transform.SetScaleX(flipped ? -scaleX : scaleX);
            animator.transform.SetLocalPositionX(flipped ? -offsetX : offsetX);
        }
    }
}