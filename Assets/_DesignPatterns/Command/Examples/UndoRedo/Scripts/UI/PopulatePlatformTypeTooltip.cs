using UnityEngine;

namespace DesignPatterns.Command.UndoRedo
{
    public class PopulatePlatformTypeTooltip : MonoBehaviour
    {
        [SerializeField] private GameObject colorItem;
        [SerializeField] private Transform spawnParent;

        private void Start()
        {
            PopulateTooltip();
        }

        private void PopulateTooltip()
        {
            SpawnColorItem(Platform.HiddenColor, "Hidden");
            for(PlatformEffectType effect = PlatformEffectType.None; effect < PlatformEffectType.Count; ++effect)
            {
                Color col = EffectFactory.GetPlatformColorByEffect(effect);
                string effectName = effect.ToString();
                SpawnColorItem(col, effectName);
            }
        }

        private void SpawnColorItem(Color color, string text)
        {
            GameObject clone = Instantiate(colorItem, spawnParent);
            UIColorItem item = clone.GetComponent<UIColorItem>();
            item.Display(color, text);
        }
    }
}