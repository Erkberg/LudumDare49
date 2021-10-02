using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class LevelEnd : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
            if (playerMovement)
            {
                Game.inst.OnLevelEnd();
                Destroy(gameObject);
            }
        }
    }
}