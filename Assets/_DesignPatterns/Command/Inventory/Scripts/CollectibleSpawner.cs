using DesignPatterns.Command.NPC;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command.Inventory
{
    [System.Serializable]
    public struct CollectibleSpawnData
    {
        public CollectibleType type;
        public int count;
    }

    public class CollectibleSpawner : MonoBehaviour
    {
        [SerializeField] private List<CollectibleSpawnData> collectibles;
        [SerializeField] private Vector2 bounds;

        private List<GameObject> spawnedCollectibles = new List<GameObject>();

        private void Start()
        {
            SpawnChests();
        }

        private void SpawnChests()
        {
            CollectibleFactory factory = Locator.GetService<CollectibleFactory>();

            //Spawn collectibles at random positions
            for (int index = 0; index < collectibles.Count; ++index)
            {
                CollectibleData data = factory.GetDataByType(collectibles[index].type);

                for (int index2 = 0; index2 < collectibles[index].count; ++index2)
                {
                    GameObject clone = Instantiate(data.prefab, transform);
                    clone.transform.position = new Vector3(Random.Range(-bounds.x, bounds.x), 1.0f, Random.Range(-bounds.y, bounds.y));
                    clone.transform.rotation = Quaternion.Euler(0.0f, Random.Range(0.0f, 2 * Mathf.PI), 0.0f);

                    Collectible script = clone.GetComponent<Collectible>();
                    script.Init(data);

                    spawnedCollectibles.Add(clone);
                }
            }
        }
    }
}