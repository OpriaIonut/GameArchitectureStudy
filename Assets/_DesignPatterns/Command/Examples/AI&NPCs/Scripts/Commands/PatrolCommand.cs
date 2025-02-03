

using UnityEngine;

namespace DesignPatterns.Command.NPC
{
    public class PatrolCommand : INpcCommand
    {
        private NpcCharacter npc;
        private Vector3 pos;

        public PatrolCommand(NpcCharacter npc, Vector3 targetPos)
        {
            this.npc = npc;
            this.pos = targetPos;
        }

        public void Execute()
        {
            npc.MoveToLocation(pos);
        }
    }
}