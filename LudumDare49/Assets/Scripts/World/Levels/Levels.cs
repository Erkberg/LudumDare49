using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class Levels : MonoBehaviour
    {
        public Level levelPrefab;
        public List<LevelData> levelDatas;
        public List<Level> levels;

        private float currentWidth = 0f;

        private void Awake()
        {
            CreateLevels();
        }

        private void CreateLevels()
        {
            foreach(LevelData levelData in levelDatas)
            {
                CreateLevel(levelData);
            }
        }

        private void CreateLevel(LevelData levelData)
        {
            Level level = Instantiate(levelPrefab, transform);
            level.InitFromData(levelData);
            level.SetPositionX(currentWidth);
            currentWidth += level.GetWidth();
            levels.Add(level);
        }

        public Level GetLevel(int id)
        {
            return levels.Find(x => x.id == id);
        }
    }
}