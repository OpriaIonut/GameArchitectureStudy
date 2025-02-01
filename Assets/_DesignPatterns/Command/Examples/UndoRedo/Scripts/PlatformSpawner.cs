using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject platformPrefab;
        [SerializeField] private float startZ;
        [SerializeField] private int numOfTilesZ;
        [SerializeField] private int numOfTilesX;
        [SerializeField] private float offsetBetweenTiles;

        private List<GameObject> spawnedPlatforms = new List<GameObject>();

        private void Awake()
        {
            
        }

        private void Start()
        {
            SpawnPlatforms();
        }

        private void SpawnPlatforms()
        {
            for(int index = 0; index < numOfTilesZ; ++index)
            {
                float zOffset = startZ - index * offsetBetweenTiles;
                for(int index2 = 0; index2 < numOfTilesX; ++index2)
                {
                    float xOffset = (index2 - numOfTilesX / 2) * offsetBetweenTiles;

                    GameObject clone = Instantiate(platformPrefab);
                    clone.transform.position = new Vector3(xOffset, 0.0f, zOffset);
                    spawnedPlatforms.Add(clone);
                }
            }
        }
    }
}