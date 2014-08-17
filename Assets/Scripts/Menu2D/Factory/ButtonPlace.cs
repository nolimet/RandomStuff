using UnityEngine;
using System.Collections;
namespace menu
{
    namespace factory
    {
        public class ButtonPlace : MonoBehaviour
        {
            public ButtonFactory.Buttons buttonType;
            public int FontSize = 0;
            public string Text = "";
            public int toMenu =-1;
            public string url = "";
            void Start()
            {
                ButtonFactory.makeButton(buttonType, transform.parent, transform.position, FontSize, Text, toMenu,url);
                DestroyImmediate(this.gameObject);
            }
        }
    }
}