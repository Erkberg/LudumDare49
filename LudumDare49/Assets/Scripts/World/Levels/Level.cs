using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class Level : MonoBehaviour
    {
        public LevelEnd levelEndPrefab;
        public List<LevelBlock> spawnedBlocks;

        public void InitFromData(LevelData data)
        {
            spawnedBlocks = new List<LevelBlock>();
            float currentWidth = 0f;

            for (int i = 0; i < data.blocksAmount; i++)
            {
                int blockIdPool = TryGetUnusedBlockId(data);
                LevelBlock block = Instantiate(data.blocksPool[blockIdPool], transform);
                block.SetPositionX(currentWidth);
                currentWidth += block.GetWidth();
                spawnedBlocks.Add(block);
            }
        }

        private int TryGetUnusedBlockId(LevelData data)
        {
            int counter = 0;

            while(true)
            {
                int blockIdPool = Random.Range(0, data.blocksPool.Count);
                if(HasBlockIdAlreadyBeenSpawned(data.blocksPool[blockIdPool].id))
                {
                    counter++;
                    if(counter > 16)
                    {
                        break;
                    }
                }
                else
                {
                    return blockIdPool;
                }
            }

            return Random.Range(0, data.blocksPool.Count);
        }

        private bool HasBlockIdAlreadyBeenSpawned(int id)
        {
            foreach (LevelBlock spawnedBlock in spawnedBlocks)
            {
                if (id == spawnedBlock.id)
                {
                    return true;
                }
            }

            return false;
        }

        public void SetPositionX(float x)
        {
            transform.SetLocalPositionX(x);
        }

        public float GetWidth()
        {
            float width = 0f;

            foreach(LevelBlock block in spawnedBlocks)
            {
                width += block.GetWidth();
            }

            return width;
        }
    }
}