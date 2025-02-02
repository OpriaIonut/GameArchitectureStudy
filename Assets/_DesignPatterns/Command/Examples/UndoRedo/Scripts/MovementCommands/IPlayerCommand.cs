namespace DesignPatterns.Command
{
    public interface IPlayerCommand
    {
        public bool IsValidCommand();
        public void Execute();
        public void Undo();
    }
}