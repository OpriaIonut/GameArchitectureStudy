using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public enum PlatformEffectType
    {
        None,
        Heal,
        Damage,
        Teleport,
        InvertCamera,
        HidePlatforms,
        RevealPlatforms,
        Count
    }

    public abstract class BasePlatformEffect
    {
        public abstract void Execute();
        public abstract void Undo();
    }
}
