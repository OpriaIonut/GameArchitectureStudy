namespace DesignPatterns.Command.UndoRedo
{
    public enum PlatformEffectType
    {
        None,
        Heal,
        Damage,
        //Teleport,
        //InvertCamera,
        //HidePlatforms,
        //RevealPlatforms,
        Count
    }

    public abstract class BasePlatformEffect
    {
        public abstract bool IsValid();
        public abstract void Execute();
        public abstract void Undo();
    }
}
