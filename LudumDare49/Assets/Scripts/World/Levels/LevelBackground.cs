using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD49
{
    public class LevelBackground : MonoBehaviour
    {
        public SpawnTrees spawnTrees;
        public ParticleSystem flameParticles;

        public void SpawnTrees()
        {
            spawnTrees.Spawn();
        }
    }
}