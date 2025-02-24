namespace DesignPatterns.Command.NPC
{
    public class InspectChestCommand : INpcCommand
    {
        private NpcCharacter character;
        private Chest chest;

        public InspectChestCommand(NpcCharacter character, Chest chest)
        {
            this.character = character;
            this.chest = chest;
        }

        public void Execute()
        {
            character.InspectChest(chest);
        }
    }
}