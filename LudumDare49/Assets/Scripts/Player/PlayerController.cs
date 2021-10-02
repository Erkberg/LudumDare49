using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class PlayerController : MonoBehaviour
    {
        public Player player;
        public PlayerMovement playerMovement;
        public float maxPlayerDistanceX = 14f;

        public enum Player
        {
            P1,
            P2
        }

        public void Die()
        {
            gameObject.SetActive(false);
        }
    }
}