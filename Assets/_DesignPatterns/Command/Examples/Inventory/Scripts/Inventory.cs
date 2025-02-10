using System;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command.Inventory
{
    public class InventoryItem
    {
        public CollectibleType type;
        public int count;
    }

    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int maxItemsPerSlot = 3;
        [SerializeField] private int inventorySize = 16;

        private List<InventoryItem> items;

        private void Awake()
        {
            Locator.RegisterService(this);
        }

        private void Start()
        {
            items = new List<InventoryItem>(inventorySize);
            for(int index = 0; index < inventorySize; ++index)
            {
                items.Add(new InventoryItem());
            }
        }

        public void AddItem(CollectibleType type, int count)
        {
            //Go through the inventory and add the desired items
            int availableItems = count;
            while (availableItems > 0) 
            {
                for (int index = 0; index < items.Count; ++index)
                {
                    int itemsToAdd = 0;

                    //If it is an empty stack, initialize it
                    if (items[index].count == 0)
                    {
                        items[index].type = type;
                        itemsToAdd = Mathf.Min(maxItemsPerSlot, availableItems);
                    }
                    else if (items[index].type == type && items[index].count < maxItemsPerSlot)
                    {
                        //Otherwise check to make sure we don't go over the maximum limit per stack. If we would go over, add items up until the limit, and add the rest in a different slot.
                        int canAddItems = maxItemsPerSlot - items[index].count;
                        itemsToAdd = Mathf.Min(canAddItems, availableItems);
                    }

                    if(itemsToAdd > 0)
                    {
                        items[index].count += itemsToAdd;
                        availableItems -= itemsToAdd;
                        if (availableItems <= 0)
                            break;
                    }
                }
            }
        }

        //Adds how many items you specify up until the maximum possible count, and returns how many items were added
        public int AddItem(CollectibleType type, int count, int index)
        {
            int itemsToAdd = 0;

            //If it is an empty stack, initialize it
            if (items[index].count == 0)
            {
                items[index].type = type;
                itemsToAdd = Mathf.Min(maxItemsPerSlot, count);
            }
            else if (items[index].type == type && items[index].count < maxItemsPerSlot)
            {
                //Otherwise check to make sure we don't go over the maximum limit per stack. If we would go over, add items up until the limit, and add the rest in a different slot.
                int canAddItems = maxItemsPerSlot - items[index].count;
                itemsToAdd = Mathf.Min(canAddItems, count);
            }

            if (itemsToAdd > 0)
                items[index].count += itemsToAdd;

            //Return how many items were added;
            return itemsToAdd;
        }

        public void RemoveItem(int index, int count)
        {
            items[index].count = Math.Max(items[index].count - count, 0);
        }

        public void RemoveStack(int index)
        {
            items[index].count = 0;
        }

        public bool IsFullStack(int index)
        {
            return items[index].count == maxItemsPerSlot;
        }

        public int GetStackCount(int index)
        {
            return items[index].count;
        }

        public InventoryItem GetItemByIndex(int index) { return items[index]; }

        public int GetMaxInventorySize() { return inventorySize; }

        public int GetTotalCollectibleCount(CollectibleType type)
        {
            int count = 0;
            foreach (InventoryItem item in items)
            {
                if (item.type == type)
                    count += item.count;
            }
            return count;
        }
    }
}