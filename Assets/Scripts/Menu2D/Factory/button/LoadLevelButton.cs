using UnityEngine;
using System.Collections;
using menu.factory.action;
namespace menu
{
    namespace factory
    {
        namespace button
        {
            public class LoadLevelButton : ButtonGeneric
            {

                public static GameObject loadLevelButton (Material m, Font ft, int Size, string text, string url)
                {
                    GameObject b = MakeBase(m, ft, text, Size);
                    b.AddComponent<LoadLevel>().init(url);

                    return b;
                }
            }
        }
    }
}