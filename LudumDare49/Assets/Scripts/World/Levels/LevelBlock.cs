using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class LevelBlock : MonoBehaviour
    {
        public LevelBlockGround ground;

        public void SetPositionX(float x)
        {
            transform.SetLocalPositionX(x);
        }

        public float GetWidth()
        {
            return ground.GetWidth();
        }
    }
}