using UnityEngine;
using System.Collections;
namespace menu
{
    namespace factory
    {
        public class FactoryInti : MonoBehaviour
        {
            public Material fontMat;
            public Font font;
            void Start()
            {
                ButtonFactory.font = font;
                ButtonFactory.fontMat = fontMat;
            }
        }
    }
}