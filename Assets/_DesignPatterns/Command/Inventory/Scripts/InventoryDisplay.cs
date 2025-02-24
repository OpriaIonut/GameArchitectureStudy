
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command.Inventory
{
    public class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryPanel;
        [SerializeField] private GameObject uiItemPrefab;
        [SerializeField] private Transform spawnParent;

        private List<GridItem> spawnedItems = new List<GridItem>();
        private bool isActive = false;

        private void Awake()
        {
            Locator.RegisterService(this);
        }

        private void Start()
        {
            Init();
            SetInventoryActive(false);
        }

        private void Init()
        {
            Inventory inventory = Locator.GetService<Inventory>();
            for(int index = 0; index < inventory.GetMaxInventorySize(); ++index)
            {
                GameObject clone = Instantiate(uiItemPrefab, spawnParent);
                GridItem script = clone.GetComponent<GridItem>();
                spawnedItems.Add(script);
            }
        }

        public void ToggleInventory()
        {
            isActive = !isActive;
            SetInventoryActive(isActive);
        }

        public void SetInventoryActive(bool active)
        {
            isActive = active;
            inventoryPanel.SetActive(isActive);
            if (isActive)
                UpdateDisplay();
        }

        public bool IsInventoryActive() { return inventoryPanel.activeInHierarchy; }

        public void UpdateDisplay()
        {
            if (!isActive)
                return;

            Inventory inventory = Locator.GetService<Inventory>();
            CollectibleFactory factory = Locator.GetService<CollectibleFactory>();

            for(int index = 0; index < inventory.GetMaxInventorySize(); ++index)
            {
                InventoryItem item = inventory.GetItemByIndex(index);

                spawnedItems[index].SetCounter(item.count);
                if (item.count == 0)
                    spawnedItems[index].HideImage();
                else
                {
                    CollectibleData data = factory.GetDataByType(item.type);
                    spawnedItems[index].SetImage(data.uiImage);
                }
            }
        }
    }
}