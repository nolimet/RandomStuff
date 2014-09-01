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
            inv[9] = new TestItem();
            inv[10] = new TestItem();
            //non-test
            foreach (GenericItem r in inv)
            {
                r.init();
                Debug.Log(r.Name);
            }

            
        }

        void OnGUI()
        {
            for(int i = 0; i < inv.Length; i++)
            {
                GUI.Label(new Rect(64*i,64*(i/10),64,64),inv[i].texture);
            }
        }
    }

    [System.Serializable]
   public class InvRow{
        public List<GenericItem> row = new List<GenericItem>(10);
    }
}