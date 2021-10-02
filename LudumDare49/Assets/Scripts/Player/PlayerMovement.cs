using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool movementEnabled = true;
        public PlayerController playerController;
        public Rigidbody2D rb2D;
        public GroundChecker groundChecker;

        public float moveSpeed = 1f;
        public float runMultiplier = 1.5f;
        public float jumpStrength = 6f;
        public bool applyExtraGravity = true;
        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;

        private void OnEnable()
        {        
            if(IsP1())
                Game.inst.input.onJumpP1 += OnJump;
            else
                Game.inst.input.onJumpP2 += OnJump;
        }

        private void OnDisable()
        {
            if(IsP1())
                Game.inst.input.onJumpP1 -= OnJump;
            else
                Game.inst.input.onJumpP2 -= OnJump;
        }

        private void Update()
        {
            MoveHorizontal();
            MoveVertical();
        }

        private bool IsP1()
        {
            return playerController.player == PlayerController.Player.P1;
        }

        private void MoveHorizontal()
        {
            rb2D.SetVelocityX(GetMovementHorizontal());
        }

        private float GetMovementHorizontal()
        {
            float movement = 0f;

            if(IsP1())
            {
                movement = Game.inst.input.GetMoveXP1();
                if (Game.inst.input.GetRunP1())
                    movement *= runMultiplier;
            }
            else
            {
                movement = Game.inst.input.GetMoveXP2();
                if (Game.inst.input.GetRunP2())
                    movement *= runMultiplier;
            }

            movement *= moveSpeed;

            return movement;
        }

        private void MoveVertical()
        {
            if (applyExtraGravity)
            {
                if (rb2D.velocity.y < 0f)
                {
                    ApplyExtraGravity(fallMultiplier);
                }
                else if (rb2D.velocity.y > 0f && !IsJumpDown())
                {
                    ApplyExtraGravity(lowJumpMultiplier);
                }
            }
        }

        private bool IsJumpDown()
        {
            if (IsP1())
                return Game.inst.input.GetJumpP1();
            else
                return Game.inst.input.GetJumpP2();
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