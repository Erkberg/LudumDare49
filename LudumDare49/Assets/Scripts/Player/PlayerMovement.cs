using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class PlayerMovement : MonoBehaviour
    {
        public Rigidbody2D rb2D;
        public GroundChecker groundChecker;

        public float moveSpeed = 1f;
        public float jumpStrength = 6f;
        public bool applyExtraGravity = true;
        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;

        private void OnEnable()
        {
            Game.inst.input.onJump += OnJump;
        }

        private void OnDisable()
        {
            Game.inst.input.onJump -= OnJump;
        }

        private void Update()
        {
            MoveHorizontal();
            MoveVertical();
        }

        private void MoveHorizontal()
        {
            rb2D.SetVelocityX(Game.inst.input.GetMoveX() * moveSpeed);
        }

        private void MoveVertical()
        {
            if (applyExtraGravity)
            {
                if (rb2D.velocity.y < 0f)
                {
                    ApplyExtraGravity(fallMultiplier);
                }
                else if (rb2D.velocity.y > 0f && !Game.inst.input.GetJump())
                {
                    ApplyExtraGravity(lowJumpMultiplier);
                }
            }
        }

        private void OnJump()
        {
            if (groundChecker.isGrounded)
            {
                rb2D.SetVelocityY(jumpStrength);
            }
        }

        private void ApplyExtraGravity(float multiplier)
        {
            rb2D.AddVelocityY(Physics2D.gravity.y * (multiplier - 1f) * Time.deltaTime);
        }
    }
}