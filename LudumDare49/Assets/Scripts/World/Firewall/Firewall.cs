using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class Firewall : MonoBehaviour
    {
        public float moveSpeed = 1f;

        private void Update()
        {
            transform.SetLocalPositionX(transform.position.x + moveSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
            if(playerMovement)
            {
                Game.inst.RestartGame();
            }
        }
    }
}