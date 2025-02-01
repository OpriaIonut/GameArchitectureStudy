using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class HealEffect : BasePlatformEffect
    {
        public override void Execute()
        {
            Player player = Locator.GetService<Player>();
            player.Heal(10);
        }

        public override void Undo()
        {
            Player player = Locator.GetService<Player>();
            player.TakeDamage(10);
        }
    }
}