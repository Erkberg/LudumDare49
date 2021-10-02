using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class Level : MonoBehaviour
    {
        public LevelEnd levelEndPrefab;
        public List<LevelBlock> blocks;

        public void InitFromData(LevelData data)
        {
            blocks = new List<LevelBlock>();
            List<LevelBlock> blocksPool = data.blocks;
            float currentWidth = 0f;

            for (int i = 0; i < data.blocksAmount; i++)
            {
                int blockId = Random.Range(0, blocksPool.Count);
                LevelBlock block = Instantiate(blocksPool[blockId], transform);
                block.SetPositionX(currentWidth);
                currentWidth += block.GetWidth();
                blocks.Add(block);
            }
        }

        public void SetPositionX(float x)
        {
            transform.SetLocalPositionX(x);
        }

        public float GetWidth()
        {
            float width = 0f;

            foreach(LevelBlock block in blocks)
            {
                width += block.GetWidth();
            }

            return width;
        }
    }
}