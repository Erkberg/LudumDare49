using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LD49
{
    public class GameInput : MonoBehaviour
    {
        public Action onJump;

        private InputActions inputActions;
        private InputAction moveP1;
        private InputAction moveP2;
        private InputAction jumpP1;
        private InputAction jumpP2;

        private void Awake()
        {
            inputActions = new InputActions();
        }

        private void Update()
        {
            
        }

        private void OnEnable()
        {
            moveP1 = inputActions.Player.MoveP1;
            moveP1.Enable();
            moveP2 = inputActions.Player.MoveP2;
            moveP2.Enable();
            jumpP1 = inputActions.Player.JumpP1;
            jumpP1.Enable();
            jumpP1.performed += OnJump;
        }

        private void OnDisable()
        {
            moveP1.Disable();
            moveP2.Disable();
            jumpP1.performed -= OnJump;
            jumpP1.Disable();
        }

        public Vector2 GetMove()
        {
            return moveP1.ReadValue<Vector2>();
        }

        public float GetMoveX()
        {
            return GetMove().x;
        }

        public float GetMoveY()
        {
            return GetMove().y;
        }

        public Vector2 GetLook()
        {
            return moveP2.ReadValue<Vector2>();
        }

        private void OnJump(InputAction.CallbackContext ctx)
        {
            onJump?.Invoke();
        }

        public bool GetJump()
        {
            return jumpP1.ReadValue<float>() == 1f; 
        }

        public void OnJump(InputValue value)
        {
            Debug.Log(value.Get<float>());
        }
    }
}