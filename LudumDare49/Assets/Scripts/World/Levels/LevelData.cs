using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    [CreateAssetMenu]
    public class LevelData : ScriptableObject
    {
        public int id;
        public int blocksAmount = 1;
        public List<LevelBlock> blocksPool;
    }
}