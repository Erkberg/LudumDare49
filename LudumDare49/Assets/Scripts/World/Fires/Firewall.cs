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

        public void OnLevelEndReached()
        {
            moveSpeed *= 1.2f;
        }

        private void Update()
        {
            transform.SetLocalPositionX(transform.position.x + moveSpeed * Time.deltaTime);

            CheckCatchupToPlayer();
        }

        private void CheckCatchupToPlayer()
        {
            float playerX = Game.inst.player.transform.position.x;
            if (transform.position.x + maxDistanceToPlayer < playerX)
            {
                transform.SetPositionX(playerX - maxDistanceToPlayer);
            }
        }
    }
}