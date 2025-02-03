using System.Collections.Generic;

namespace DesignPatterns.Command.NPC
{
    //In case we want to extend this system to support other NPCs in the future, we would symply add a Dictionary<NPC, Queue<INpcCommand>>, which would store queues for each individual NPC.
    public class NpcCommandDispatcher
    {
        private static Queue<INpcCommand> commandQueue = new Queue<INpcCommand>();

        private static INpcCommand activeCommand = null;

        //Schedule a command for use. In case we have no active commands, it will execute it, otherwise it will chain it to be executed later on
        public static void ScheduleCommand(INpcCommand command)
        {
            if(activeCommand == null)
            {
                activeCommand = command;
                activeCommand.Execute();
            }
            else
                commandQueue.Enqueue(command);
        }

        //If we are finished with a command, start a new one (if we have any)
        public static void OnFinishedCommand()
        {
            if (commandQueue.Count > 0)
            {
                activeCommand = commandQueue.Dequeue();
                activeCommand.Execute();
            }
            else
                activeCommand = null;
        }
    }
}