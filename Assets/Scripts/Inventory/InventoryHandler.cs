using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace InvFrameWork
{
    public class InventoryHandler : MonoBehaviour
    {
        [SerializeField]
        public GenericItem[] inv = new GenericItem[20];

        void Start()
        {
            InventoryStatics.InvHandler = this;

            inv[9] = new TestItem();
            inv[10] = new TestItem();
            //non-test
            foreach (GenericItem r in inv)
            {
                r.init();
                newItem(r);
            }

            
        }

        void dOnGUI()
        {
            for(int i = 0; i < inv.Length; i++)
            {
               // GUI.Label(new Rect(64*i,64*(i/10),64,64),inv[i].texture);
            }
        }

        void newItem(GenericItem item)
        {
            if (item.RenderItem == null&& item.Name!="nullItem" )
            {
                item.RenderItem = new GameObject();
                GameObject I = item.RenderItem;

                I.name = item.Name;

                SpriteRenderer spr = I.AddComponent<SpriteRenderer>();
                spr.sprite = (Sprite) item.texture;

                BoxCollider col = I.AddComponent<BoxCollider>();

                I.transform.parent = transform;
            }
        }
    }
}