using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class Game : MonoBehaviour
    {
        public static Game inst;

        public GameInput input;
        public PlayerController player;

        private void Awake()
        {
            inst = this;
        }
    }
}