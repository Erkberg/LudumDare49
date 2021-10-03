using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

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

        public void AdjustFireToLevel()
        {
            if(Game.levelReached > 0)
            {
                flameParticles.SetEmissionOverTime(Game.levelReached * 250);
            }
        }
    }
}