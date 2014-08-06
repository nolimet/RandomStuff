using UnityEngine;
using System.Collections;
namespace menu
{
    namespace factory
    {
        public class ButtonPlace : MonoBehaviour
        {
            public ButtonFactory.Buttons buttonType;
            public int FontSize;
            public string Text;
            public int toMenu;
            void Start()
            {
                ButtonFactory.makeButton(buttonType, transform.parent, transform.position, FontSize, Text, toMenu);
                DestroyImmediate(this);
            }
        }
    }
}