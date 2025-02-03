namespace DesignPatterns.Command.UndoRedo
{
    public enum MoveDirection
    {
        Up, Left, Down, Right
    }

    public class MovementCommand : IPlayerCommand
    {
        private Player player;
        private MoveDirection direction;

        public MovementCommand(Player player, MoveDirection direction)
        {
            this.player = player;
            this.direction = direction;
        }

        public bool IsValidCommand()
        {
            return player.IsValidMove(direction);
        }

        public void Execute()
        {
            player.Move(direction);
            player.CurrentPlatform.RevealColor();
            player.CurrentPlatform.ApplyEffect();
        }

        public void Undo()
        {
            MoveDirection oppositeDir;
            if (direction == MoveDirection.Up)
                oppositeDir = MoveDirection.Down;
            else if (direction == MoveDirection.Left)
                oppositeDir = MoveDirection.Right;
            else if (direction == MoveDirection.Right)
                oppositeDir = MoveDirection.Left;
            else
                oppositeDir = MoveDirection.Up;

            player.CurrentPlatform.SetHiddenColor();
            player.CurrentPlatform.UndoEffect();

            player.Move(oppositeDir);
        }
    }
}