using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command.UndoRedo
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject platformPrefab;
        [SerializeField] private Platform startingPlatform;
        [SerializeField] private float startZ;
        [SerializeField] private int numOfTilesZ;
        [SerializeField] private int numOfTilesX;
        [SerializeField] private float offsetBetweenTiles;

        private List<Platform> spawnedPlatforms = new List<Platform>();

        private void Awake()
        {
            Locator.RegisterService(this);
        }

        private void Start()
        {
            spawnedPlatforms.Add(startingPlatform);
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

                    Platform script = clone.GetComponent<Platform>();
                    spawnedPlatforms.Add(script);
                }
            }
        }

        private int FindPlatformIndex(Platform platform)
        {
            for(int index = 0; index < spawnedPlatforms.Count; ++index)
            {
                if(platform == spawnedPlatforms[index]) 
                    return index;
            }
            return -1;
        }

        public bool DoesPlatformExistInDir(Platform platform, MoveDirection direction)
        {
            int platformIndex = FindPlatformIndex(platform);
            if (platformIndex == -1) //Validate if platform exists
                return false;

            //In case we are on the starting platform, we can only move down
            if(platformIndex == 0)
            {
                if (direction == MoveDirection.Down)
                    return true;
                return false;
            }

            //If we are on the first row, after the starting platform, we can only move up from the middle tile
            if(direction == MoveDirection.Up && platformIndex <= numOfTilesX)
            {
                if (platformIndex == (int)Mathf.Ceil(numOfTilesX / 2.0f))
                    return true;
                return false;
            }

            //If we are on the edges, make sure we don't move outside of it
            if (platformIndex % numOfTilesX == 0 && direction == MoveDirection.Right)
                return false;
            if (platformIndex % numOfTilesX == 1 && direction == MoveDirection.Left)
                return false;

            //Make sure that if we are on the last row, we cannot go downwards
            if ((platformIndex - 1) / numOfTilesX == (numOfTilesZ - 1) && direction == MoveDirection.Down)
                return false;

            return true;
        }

        public Platform GetPlatformByDirection(Platform platform, MoveDirection direction)
        {
            //Make sure that we can reach a valid platform, and return null otherwise
            int platformIndex = FindPlatformIndex(platform);
            if (!DoesPlatformExistInDir(platform, direction))
                return null;

            //Find the new platform index based on the direction that we want to move in
            //All invalid moves are filtered out in the function DoesPlatformExistInDir, so we can make assumptions that every move is valid here
            int targetIndex = -1;
            switch (direction)
            {
                case MoveDirection.Up:
                    if (platformIndex <= numOfTilesX)
                        targetIndex = 0;
                    else
                        targetIndex = platformIndex - numOfTilesX;
                    break;
                case MoveDirection.Left:
                    targetIndex = platformIndex - 1;
                    break;
                case MoveDirection.Down:
                    if (platformIndex == 0)
                        targetIndex = (int)Mathf.Ceil(numOfTilesX / 2.0f);
                    else
                        targetIndex = platformIndex + numOfTilesX;
                    break;
                case MoveDirection.Right:
                    targetIndex = platformIndex + 1;
                    break;
            }

            return spawnedPlatforms[targetIndex];
        }
    }
}