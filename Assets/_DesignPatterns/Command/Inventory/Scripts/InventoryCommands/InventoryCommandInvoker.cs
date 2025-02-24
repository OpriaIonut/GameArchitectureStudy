namespace DesignPatterns.Command.Inventory
{
    public static class InventoryCommandInvoker
    {
        public static void TriggerCommand(IInventoryCommand command)
        {
            command.Execute();
        }
    }
}