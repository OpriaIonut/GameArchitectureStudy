using UnityEngine;

namespace DesignPatterns.Command.Inventory
{
    public class CollectItemCommand : IInventoryCommand
    {
        private CollectibleType type;
        private int count;

        public CollectItemCommand(CollectibleType type, int count)
        {
            this.type = type;
            this.count = count;
        }

        public void Execute()
        {
            Inventory inventory = Locator.GetService<Inventory>();
            inventory.AddItem(type, count);

            InventoryDisplay display = Locator.GetService<InventoryDisplay>();
            display.UpdateDisplay();
        }
    }
}