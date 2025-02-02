using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class MovementCommandInvoker : MonoBehaviour
    {
        private Stack<IPlayerCommand> undoStack = new Stack<IPlayerCommand>();
        private Stack<IPlayerCommand> redoStack = new Stack<IPlayerCommand>();

        private void Start()
        {
            Locator.RegisterService(this);
        }

        public void ExecuteCommand(IPlayerCommand command)
        {
            if (command.IsValidCommand())
            {
                command.Execute();
                undoStack.Push(command);
                redoStack.Clear();
            }
        }

        public void Undo()
        {
            if (undoStack.Count == 0)
                return;

            IPlayerCommand command = undoStack.Pop();
            command.Undo();
            redoStack.Push(command);
        }

        public void Redo()
        {
            if (redoStack.Count == 0)
                return;

            IPlayerCommand command = redoStack.Pop();
            if (command.IsValidCommand())
            {
                command.Execute();
                undoStack.Push(command);
            }
        }
    }
}