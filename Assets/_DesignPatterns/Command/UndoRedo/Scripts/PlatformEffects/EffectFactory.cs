using UnityEngine;

namespace DesignPatterns.Command.UndoRedo
{
    public class EffectFactory
    {
        public static BasePlatformEffect GetEffectByType(PlatformEffectType type)
        {
            Player player = Locator.GetService<Player>();

            switch(type)
            {
                case PlatformEffectType.None:       return null;
                case PlatformEffectType.Heal:       return new HealEffect(player);
                case PlatformEffectType.Damage:     return new DamageEffect();
                default:
                    Debug.LogWarning("Effect not implemented!");
                    return null;
            }
        }

        public static Color GetPlatformColorByEffect(PlatformEffectType type)
        {
            switch (type)
            {
                case PlatformEffectType.None: return Color.white;
                case PlatformEffectType.Heal: return Color.green;
                case PlatformEffectType.Damage: return Color.red;
                //case PlatformEffectType.Teleport: return Color.blue;
                //case PlatformEffectType.InvertCamera: return Color.magenta;
                //case PlatformEffectType.HidePlatforms: return Color.yellow;
                //case PlatformEffectType.RevealPlatforms: return Color.cyan;
                default:
                    return Color.black;
            }
        }
    }
}