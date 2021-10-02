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
        private InputAction move;
        private InputAction look;
        private InputAction jump;

        private void Awake()
        {
            inputActions = new InputActions();
        }

        private void Update()
        {
            
        }

        private void OnEnable()
        {
            move = inputActions.Player.Move;
            move.Enable();
            look = inputActions.Player.Look;
            look.Enable();
            jump = inputActions.Player.Jump;
            jump.Enable();
            jump.performed += OnJump;
        }

        private void OnDisable()
        {
            move.Disable();
            look.Disable();
            jump.performed -= OnJump;
            jump.Disable();
        }

        public Vector2 GetMove()
        {
            return move.ReadValue<Vector2>();
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
            return look.ReadValue<Vector2>();
        }

        private void OnJump(InputAction.CallbackContext ctx)
        {
            onJump?.Invoke();
        }

        public bool GetJump()
        {
            return jump.ReadValue<float>() == 1f; 
        }

        public void OnJump(InputValue value)
        {
            Debug.Log(value.Get<float>());
        }
    }
}