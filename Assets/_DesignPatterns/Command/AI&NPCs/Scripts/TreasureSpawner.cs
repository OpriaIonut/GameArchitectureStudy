using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command.NPC
{
    public class TreasureSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject treasurePrefab;
        [SerializeField] private int chestsToSpawn = 10;
        [SerializeField] private int treasureChests = 2;
        [SerializeField] private Vector2 bounds;

        private List<GameObject> spawnedChests = new List<GameObject>();

        private void Start()
        {
            SpawnChests();
        }

        private void SpawnChests()
        {
            //Spawn the chests at random positions and rotations within the bounds of the game
            for(int index = 0; index < chestsToSpawn; ++index)
            {
                GameObject clone = Instantiate(treasurePrefab, transform);
                clone.transform.position = new Vector3(Random.Range(-bounds.x, bounds.x), 0.0f, Random.Range(-bounds.y, bounds.y));
                clone.transform.rotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 2 * Mathf.PI), 0.0f);
                
                spawnedChests.Add(clone);
            }

            //Pick random checks to mark as treasure
            for(int index = 0; index < treasureChests; ++index)
            {
                //Pick a random index and make sure that it isn't already a treasure chest
                int randIndex = Random.Range(0, spawnedChests.Count);
                if (spawnedChests[randIndex].name == "TreasureChest")
                {
                    index--;
                    continue;
                }

                Chest chest = spawnedChests[randIndex].GetComponent<Chest>();
                chest.Type = ChestType.Treasure;
            }
        }
    }
}