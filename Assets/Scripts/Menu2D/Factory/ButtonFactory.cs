using UnityEngine;
using System.Collections;
using menu.factory.button;
namespace menu
{
    namespace factory
    {
        public class ButtonFactory : MonoBehaviour
        {
            #region TextRelated
            public const int fontScale = 1;
            //Find fix for loading materials;
            public Material fontMat;
            public Font font;
            int fontSize;
            #endregion

            #region Enum's
            public enum Buttons
            {
                Exit,
                ChangeMenu,
                Link
            }
            #endregion

            void Start()
            {
                makeButton(Buttons.Exit,transform);
            }
            //every button needs to have own handler
            //bug Currently:
            //fontMat,font need to be set solid somewhere in a manager of sorts
            #region Creator
            public static void makeButton(Buttons bu,Transform parent, Vector3 pos = new Vector3(),  int fontSize = 20, string text = "", int ToMenu = -1)
            {
                GameObject b = null;
                switch (bu)
                {
                    case Buttons.Exit:
                       b = ExitButton.exitButton(fontMat, font, fontSize);
                        break;
                    case Buttons.ChangeMenu:
                        break;
                    default:
                        b=new GameObject();
                        b.name="buttonType.##Error##";
                        Destroy(b, 0.1f);
                        break;

                }
                b.transform.parent = parent;
                b.transform.position = pos;
            }
            #endregion
        }
    }
}