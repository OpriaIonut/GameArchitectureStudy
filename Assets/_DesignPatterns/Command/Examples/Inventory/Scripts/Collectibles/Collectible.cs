using UnityEngine;

namespace DesignPatterns.Command.Inventory
{
    public class Collectible : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRend;

        private CollectibleData data;

        public void Init(CollectibleData data)
        {
            this.data = data;

            meshRend.material.color = data.color;
        }

        public CollectibleType ItemType { get { return data.type; } }
    }
}