using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace InvFrameWork
{
    public class InventoryHandler : MonoBehaviour
    {
        [SerializeField]
        public List<InvRow> inv;

        void Start()
        {
            for(int i = 0 ;i<3;i++)
            {
                inv.Add(new InvRow());
            }
            foreach (InvRow r in inv)
            {
                for (int j = 0; j < 9; j++)
                {
                    r.row.Add(new GenericItem());
                }
            }
        }

    }

    [System.Serializable]
   public class InvRow{
        public List<GenericItem> row = new List<GenericItem>(9);
    }
}