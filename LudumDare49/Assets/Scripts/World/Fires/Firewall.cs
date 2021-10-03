using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class Firewall : MonoBehaviour
    {
        public float moveSpeed = 1f;
        public float maxDistanceToPlayer = 16f;
        public float moveSpeedMultiplier = 1.2f;

        private void Start()
        {
            SetSpeedForLevel();
        }

        public void OnLevelEndReached()
        {
            moveSpeed *= moveSpeedMultiplier;
        }

        public void SetSpeedForLevel()
        {
            if(Game.levelReached != 0)
            {
                for (int i = 0; i < Game.levelReached; i++)
                {
                    moveSpeed *= moveSpeedMultiplier;
                }
            }
        }

        private void Update()
        {
            transform.SetLocalPositionX(transform.position.x + moveSpeed * Time.deltaTime);

            CheckCatchupToPlayer();
        }

        private void CheckCatchupToPlayer()
        {
            if(Game.inst.state == Game.State.Gameplay)
            {
                float playerX = Game.inst.player1.transform.position.x;
                if (transform.position.x + maxDistanceToPlayer < playerX)
                {
                    transform.SetPositionX(playerX - maxDistanceToPlayer);
                }
            }
        }
    }
}