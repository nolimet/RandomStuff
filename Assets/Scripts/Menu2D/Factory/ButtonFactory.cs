using UnityEngine;
using System.Collections;
using menu.factory.button;
namespace menu
{
    namespace factory
    {
        public class ButtonFactory : MonoBehaviour
        {
            public const int fontScale = 1;
            public Material fontMat;
            public Font font;
            void Start()
            {
                ExitButton.exitButton(fontMat,font,20);
            }
        }
    }
}