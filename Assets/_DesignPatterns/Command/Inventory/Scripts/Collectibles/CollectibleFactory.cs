using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command.Inventory
{
    public class CollectibleFactory : MonoBehaviour
    {
        [SerializeField] private List<CollectibleData> data;

        private void Awake()
        {
            Locator.RegisterService(this);
        }

        public CollectibleData GetDataByType(CollectibleType type)
        {
            for(int index = 0; index < data.Count; ++index)
            {
                if(data[index].type == type)
                    return data[index];
            }
            return new CollectibleData();
        }
    }
}