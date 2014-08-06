using UnityEngine;
using System.Collections;
using menu.factory.action;
namespace menu
{
    public class MenuManager : MonoBehaviour
    {

        public ChangeMenu[] buttons;
        public MoveToV2[] Menus;
        public int currentMenuID;
        private int MenuLastFrame;
        // Use this for initialization
        void Start()
        {
            buttons = GetComponentsInChildren<ChangeMenu>();
            for (int i = 0; i < Menus.Length; i++)
            {
                Menus[i].menuID = i;
               if(Application.isEditor)
                   Menus[i].name = "[" + i + "]" + Menus[i].name;
            }
            Menus[0].move = true;
            
        }

        // Update is called once per frame
        void Update()
        {
            int l = buttons.Length;
            int k = Menus.Length;
            for (int i = 0; i < l; i++)
            {
                if (buttons[i].State)
                {
                    buttons[i].State = false;
                    for (int j = 0; j < k; j++)
                    {
                        Menus[j].move = false;
                        Menus[j].atNewPos = false;
                        if (Menus[j].menuID == buttons[i].OpenMenuID)
                        {
                            Menus[j].move = true;
                            currentMenuID = j;
                        }
                    }
                }
            }
        }
    }
}
