using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Menu
{
    namespace Rotating
    {
        public class Controler : MonoBehaviour
        {
            public static string menuTag = "Menu";
            public static string menuButtonTag = "MenuButton";
            public float distfromCenter = 10f;
            public List<MenuObject> Menus = new List<MenuObject>();
            public List<MenuButton> Button = new List<MenuButton>();

            int currentMenu = -1;
         //   bool rotationDone = false;
            void Start()
            {
                object[] allObjects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) ;
                foreach (GameObject go in allObjects)
                {
                    if (go.tag == menuTag)
                    {
                        Menus.Add(go.GetComponent<MenuObject>());
                        go.transform.parent = transform;
                    }
                }
                int i = 0;
                int l = Menus.Count;
                foreach (MenuObject mo in Menus)
                {

                    mo.SetPos(Quaternion.Euler(0, 360f / l * i, 0f), distfromCenter, i);
                    i++;
                }
            }

            void Update()
            {
                int l = Button.Count;
                for (int i = 0; i < l; i++)
                {
                    if (Button[i].Activated)
                    {
                        Button[i].Activated = false;
                    }
                }
                if (360f / l * currentMenu - 0.3f > transform.rotation.eulerAngles.z)
                {
                    transform.Rotate(0, 0, 4f);
                }
            }

            void setCurrentMenu(int index)
            {
                foreach (MenuObject mo in Menus)
                {
                    mo.currentMenu = false;
                }

                Menus[index].currentMenu = true;
                currentMenu = index;
            }
        }
    }
}