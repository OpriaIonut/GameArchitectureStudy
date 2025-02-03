using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command.UndoRedo
{
    public class MovementCommandInvoker : MonoBehaviour
    {
        private Stack<IPlayerCommand> undoStack = new Stack<IPlayerCommand>();
        private Stack<IPlayerCommand> redoStack = new Stack<IPlayerCommand>();

        private void Awake()
        {
            Locator.RegisterService(this);
        }

        private void Start()
        {
            InputHandler input = Locator.GetService<InputHandler>();
            input.AddListener_undoBtnPress(Undo);
            input.AddListener_redoBtnPress(Redo);
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