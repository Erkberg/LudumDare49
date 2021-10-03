using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class Level : MonoBehaviour
    {
        public int id;
        public LevelEnd levelEndPrefab;
        public LevelEnd levelEnd;
        public List<LevelBlock> spawnedBlocks;

        public void InitFromData(LevelData data)
        {
            id = data.id;
            spawnedBlocks = new List<LevelBlock>();
            float currentWidth = 0f;
            float lastBlockWidth = 0f;

            for (int i = 0; i < data.blocksAmount; i++)
            {
                int blockIdPool = TryGetUnusedBlockId(data);
                LevelBlock block = Instantiate(data.blocksPool[blockIdPool], transform);
                block.SpawnBackground();
                block.SetPositionX(currentWidth + block.GetWidth() / 2);
                currentWidth += block.GetWidth();
                spawnedBlocks.Add(block);
                lastBlockWidth = block.GetWidth();
            }

            levelEnd = Instantiate(levelEndPrefab, transform);
            levelEnd.SetPositionX(currentWidth);
            levelEnd.id = data.id;

            gameObject.name += $"_{data.id}";            
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