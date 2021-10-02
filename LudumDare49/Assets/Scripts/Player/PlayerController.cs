using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class PlayerController : MonoBehaviour
    {
        public Player player;
        public PlayerMovement playerMovement;

        public enum Player
        {
            P1,
            P2
        }
    }
}