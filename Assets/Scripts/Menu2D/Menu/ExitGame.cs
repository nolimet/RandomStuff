using UnityEngine;
using System.Collections;
namespace menu_old
{
    public class ExitGame : TriggerV2
    {
        protected override void IWillDo()
        {
            base.IWillDo();
            Application.Quit();
        }
    }
}