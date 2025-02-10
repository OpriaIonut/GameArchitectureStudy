using UnityEngine;

namespace DesignPatterns.Command.Inventory
{
    public enum CollectibleType
    {
        Sword,
        Shield,
        HpPotion,
        MpPotion,
        Food
    }

    [System.Serializable]
    public struct CollectibleData
    {
        public CollectibleType type;
        public GameObject prefab;
        public Color color;
        public Texture2D uiImage;
    }
}