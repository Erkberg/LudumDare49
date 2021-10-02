using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class StableGate : MonoBehaviour
    {
        public GameObject doorObject;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
            if (playerMovement && Game.inst.input.GetRunP1())
            {
                Game.inst.OnP2Freed();
                Destroy(doorObject);
                Destroy(gameObject);
            }
        }
    }
}