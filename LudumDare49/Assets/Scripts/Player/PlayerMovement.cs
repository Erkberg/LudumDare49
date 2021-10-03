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
        public PlayerAnimation playerAnimation;

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
            if(movementEnabled)
            {
                MoveHorizontal();
                MoveVertical();

                if(groundChecker.isGrounded && !groundChecker.wasGroundedLastFrame)
                    Game.inst.audio.PlayLandSound();
            }
        }

        public void Stop()
        {
            rb2D.velocity = Vector2.zero;
        }

        private bool IsP1()
        {
            return playerController.player == PlayerController.Player.P1;
        }

        private void MoveHorizontal()
        {
            float movement = GetMovementHorizontal();
            rb2D.SetVelocityX(movement);
            if (movement > 0f)
                playerAnimation.SetFlipped(false);
            else if (movement < 0f)
                playerAnimation.SetFlipped(true);
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

            if (!CanMoveInDirection(movement))
                movement = 0f;

            return movement;
        }

        private bool CanMoveInDirection(float dir)
        {
            if(Game.inst.activeP2)
            {
                float p1x = Game.inst.player1.transform.position.x;
                float p2x = Game.inst.player2.transform.position.x;
                float distance = p1x - p2x;
                distance = Mathf.Abs(distance);

                if(distance >= playerController.maxPlayerDistanceX)
                {
                    if((playerController.player == PlayerController.Player.P1 & dir < 0f && p1x < p2x && Game.inst.P2Alive()) ||
                        (playerController.player == PlayerController.Player.P1 & dir > 0f && p1x > p2x && Game.inst.P2Alive()) ||
                        (playerController.player == PlayerController.Player.P2 & dir < 0f && p2x < p1x && Game.inst.P1Alive()) ||
                        (playerController.player == PlayerController.Player.P2 & dir > 0f && p2x > p1x && Game.inst.P1Alive()))
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return true;
            }
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
            if (groundChecker.isGrounded && movementEnabled)
            {
                rb2D.SetVelocityY(jumpStrength);
                Game.inst.audio.PlayJumpSound();
            }
        }

        private void ApplyExtraGravity(float multiplier)
        {
            rb2D.AddVelocityY(Physics2D.gravity.y * (multiplier - 1f) * Time.deltaTime);
        }

        public bool IsWalking()
        {
            return rb2D.velocity.x != 0f;
        }

        public bool IsRunning()
        {
            if (IsP1() && Game.inst.input.GetRunP1())
            {
                return true;
            }
            else if (!IsP1() && Game.inst.input.GetRunP2())
            {
                return true;
            }

            return false;
        }

        public bool IsJumping()
        {
            return !groundChecker.isGrounded;
        }
    }
}