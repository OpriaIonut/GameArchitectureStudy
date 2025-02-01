using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class DamageEffect : BasePlatformEffect
    {
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