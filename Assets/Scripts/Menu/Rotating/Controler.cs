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
            public float distfromCenter = 10f;
            public List<MenuObject> Menus = new List<MenuObject>();
            public List<MenuButton> Button = new List<MenuButton>();
            void Start()
            {
                object[] allObjects = FindObjectsOfTypeAll(typeof(GameObject)) ;
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
                
            }
        }
    }
}