using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class LevelBlockGround : MonoBehaviour
    {
        public BoxCollider2D coll;

        public float GetWidth()
        {
            return coll.size.x * transform.localScale.x;
        }
    }
}