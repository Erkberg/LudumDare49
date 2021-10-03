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
        private LevelBackground bg;

        public void SpawnBackground()
        {
            bg = Instantiate(backgroundPrefab, transform);
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

        public void AdjustFireToLevel()
        {
            bg.AdjustFireToLevel();
        }
    }
}