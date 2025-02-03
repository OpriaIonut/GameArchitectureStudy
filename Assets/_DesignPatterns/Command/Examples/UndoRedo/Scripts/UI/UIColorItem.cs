using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Command.UndoRedo
{
    public class UIColorItem : MonoBehaviour
    {
        [SerializeField] private Image img;
        [SerializeField] private TextMeshProUGUI nameTag;

        public void Display(Color color, string text)
        {
            img.color = color;
            nameTag.text = text;
        }
    }
}