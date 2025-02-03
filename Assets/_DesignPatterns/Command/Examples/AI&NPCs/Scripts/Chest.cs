using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command.NPC
{
    public enum ChestType
    {
        Empty, Treasure
    }

    public class Chest : MonoBehaviour
    {
        [SerializeField] private ChestType type = ChestType.Empty;
        [SerializeField] private List<Color> typeColor = new List<Color>();
        [SerializeField] private MeshRenderer rend;

        public ChestType Type { get { return type; } set { type = value; } }

        public void ShowChestType()
        {
            rend.material.color = typeColor[(int)type];
        }
    }
}