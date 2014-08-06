using UnityEngine;
using System.Collections;
namespace menu
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