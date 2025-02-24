namespace DesignPatterns.Command.UndoRedo
{
    public class DamageEffect : BasePlatformEffect
    {
        public override bool IsValid() { return true; }

        public override void Execute()
        {
            Player player = Locator.GetService<Player>();
            player.TakeDamage(10);
        }

        public override void Undo()
        {
            Player player = Locator.GetService<Player>();
            player.Heal(10);
        }
    }
}