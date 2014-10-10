using UnityEngine;
using System.Collections;
namespace InvFrameWork
{
    public class TestItem:GenericItem
    {
        override public void init()
        {
            base.init();
            genericItem("Test", 16);
        }
    }
}
