using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LD49
{
    public class GameInput : MonoBehaviour
    {
        public Action onJumpP1;
        public Action onJumpP2;

        private InputActions inputActions;
        private InputAction moveP1;
        private InputAction moveP2;
        private InputAction jumpP1;
        private InputAction jumpP2;
        private InputAction runP1;
        private InputAction runP2;
        private InputAction menu;
        private InputAction cheat;

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
            jumpP1.performed += OnJumpP1;
            jumpP2 = inputActions.Player.JumpP2;
            jumpP2.Enable();
            jumpP2.performed += OnJumpP2;
            runP1 = inputActions.Player.RunP1;
            runP1.Enable();
            runP2 = inputActions.Player.RunP2;
            runP2.Enable();
            menu = inputActions.Player.Menu;
            menu.Enable();
            menu.performed += OnMenuButton;
            cheat = inputActions.Player.Cheat;
            cheat.Enable();
            cheat.performed += OnCheatDown;
            cheat.canceled += OnCheatUp;
        }

        private void OnDisable()
        {
            moveP1.Disable();
            moveP2.Disable();
            jumpP1.performed -= OnJumpP1;
            jumpP1.Disable();
            jumpP2.performed -= OnJumpP2;
            jumpP2.Disable();
            runP1.Disable();
            runP2.Disable();
            menu.performed -= OnMenuButton;
            menu.Disable();
            cheat.performed -= OnCheatDown;
            cheat.canceled -= OnCheatUp;
            cheat.Disable();
        }

        public float GetMoveXP1()
        {
            return moveP1.ReadValue<float>();
        }

        public float GetMoveXP2()
        {
            return moveP2.ReadValue<float>();
        }

        private void OnJumpP1(InputAction.CallbackContext ctx)
        {
            onJumpP1?.Invoke();
        }

        public bool GetJumpP1()
        {
            return jumpP1.ReadValue<float>() == 1f; 
        }

        private void OnJumpP2(InputAction.CallbackContext ctx)
        {
            onJumpP2?.Invoke();
        }

        public bool GetJumpP2()
        {
            return jumpP2.ReadValue<float>() == 1f;
        }

        public bool GetRunP1()
        {
            return runP1.ReadValue<float>() == 1f;
        }

        public bool GetRunP2()
        {
            return runP2.ReadValue<float>() == 1f;
        }

        private void OnMenuButton(InputAction.CallbackContext ctx)
        {
            Game.inst.ui.OnMenuButton();
        }

        private void OnCheatDown(InputAction.CallbackContext ctx)
        {
#if UNITY_EDITOR
            Time.timeScale = 8f;
#endif
        }

        private void OnCheatUp(InputAction.CallbackContext ctx)
        {
#if UNITY_EDITOR
            Time.timeScale = 1f;
#endif
        }
    }
}