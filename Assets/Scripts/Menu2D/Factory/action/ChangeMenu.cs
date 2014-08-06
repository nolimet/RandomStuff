using UnityEngine;
using System.Collections;
namespace menu
{
    namespace factory
    {
        namespace action
        {
            public class ChangeMenu : GenericAction
            {
                public int OpenMenuID;
                public bool State = false;
                public bool triggered = false;

                protected virtual void IWillDo()
                {
                    State = true;
                }
            }
        }
    }
}