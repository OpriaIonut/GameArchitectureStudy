namespace DesignPatterns.Command.UndoRedo
{
    public class HealEffect : BasePlatformEffect
    {
        private Player player;

        public HealEffect(Player player)
        {
            this.player = player;
        }

        public override bool IsValid()
        {
            return player.CurrentHealth < player.MaxHealth;
        }

        public override void Execute()
        {
            player.Heal(10);
        }

        public override void Undo()
        {
            player.TakeDamage(10);
        }
    }
}