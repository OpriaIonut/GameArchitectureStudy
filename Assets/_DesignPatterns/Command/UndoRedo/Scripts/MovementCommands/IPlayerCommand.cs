namespace DesignPatterns.Command.UndoRedo
{
    public interface IPlayerCommand
    {
        public bool IsValidCommand();
        public void Execute();
        public void Undo();
    }
}