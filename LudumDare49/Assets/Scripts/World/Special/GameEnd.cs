using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class GameEnd : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
            if (playerMovement)
            {
                Game.inst.OnGameEnd(playerMovement.playerController);
                Destroy(gameObject);
            }
        }
    }
}