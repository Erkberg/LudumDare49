using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class LevelBlock : MonoBehaviour
    {
        public int id;
        public LevelBlockGround ground;
        public LevelBackground backgroundPrefab;

        public void SpawnBackground()
        {
            LevelBackground bg = Instantiate(backgroundPrefab, transform);
            bg.SpawnTrees();
        }

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