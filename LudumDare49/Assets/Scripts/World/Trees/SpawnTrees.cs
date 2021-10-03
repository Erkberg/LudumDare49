using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD49
{
    public class SpawnTrees : MonoBehaviour
    {
        public GameObject treePrefab;
        public Transform ground;
        public float amount;
        public float minDistance = 1f;
        public float yPos = 0f;

        private List<Transform> spawnedTrees;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            spawnedTrees = new List<Transform>();

            for (int i = 0; i < amount; i++)
            {
                Vector3 posi = GetRandomPosition();
                int counter = 0;
                while(IsTooCloseToOthers(posi))
                {
                    posi = GetRandomPosition();
                    counter++;
                    if (counter > 100)
                        continue;
                }
                GameObject tree = Instantiate(treePrefab, transform);
                tree.transform.localPosition = posi;
                tree.transform.SetLocalRotationY(Random.Range(-360f, 360f));
                spawnedTrees.Add(tree.transform);
            }
        }

        private Vector3 GetRandomPosition()
        {
            float x = ground.localPosition.x + Random.Range(-ground.localScale.x, ground.localScale.x) / 2.1f;
            float z = ground.localPosition.z + Random.Range(-ground.localScale.z, ground.localScale.z) / 2.4f;

            return new Vector3(x, yPos, z);
        }

        private bool IsTooCloseToOthers(Vector3 posi)
        {
            foreach(Transform tree in spawnedTrees)
            {
                if (Vector3.Distance(posi, tree.position) < minDistance)
                    return true;
            }

            return false;
        }
    }
}