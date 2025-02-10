using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Command.Inventory
{
    public class GridItem : MonoBehaviour
    {
        [SerializeField] private RawImage img;
        [SerializeField] private TextMeshProUGUI text;

        public void HideImage()
        {
            img.enabled = false;
        }

        public void SetImage(Texture2D tex)
        {
            img.enabled = true;
            img.texture = tex;
        }

        public void SetCounter(int counter)
        {
            text.text = counter.ToString();
        }
    }
}