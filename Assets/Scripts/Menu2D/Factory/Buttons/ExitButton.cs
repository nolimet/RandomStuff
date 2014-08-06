using UnityEngine;
using System.Collections;
namespace menu
{
    namespace factory
    {
        namespace button
        {
            public class ExitButton : ButtonGeneric
            {
                public static GameObject exitButton(Material m,Font ft , int Size)
                {
                    GameObject b = MakeBase(m,ft,"Exit",Size);
                    b.name = "Exit";
                    return b;
                }
            }
        }
    }
}