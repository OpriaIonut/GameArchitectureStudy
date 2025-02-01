using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class Platform : MonoBehaviour
    {
        private PlatformEffectType effectType;
        private BasePlatformEffect effect;

        private MeshRenderer meshRend;

        private void Start()
        {
            meshRend = GetComponent<MeshRenderer>();

            int randIndex = Random.Range(0, (int)PlatformEffectType.Count);
            SetPlatformType((PlatformEffectType)randIndex);

            SetHiddenColor();
        }

        public void SetHiddenColor()
        {
            meshRend.material.color = new Color(0.5f, 0.5f, 0.5f);
        }

        public void RevealColor()
        {
            meshRend.material.color = EffectFactory.GetPlatformColorByEffect(effectType);
        }

        public void SetPlatformType(PlatformEffectType type)
        {
            effectType = type;
            effect = EffectFactory.GetEffectByType(type);
        }

        public void ApplyEffect()
        {
            effect.Execute();
        }

        public void UndoEffect()
        {
            effect.Execute();
        }
    }
}