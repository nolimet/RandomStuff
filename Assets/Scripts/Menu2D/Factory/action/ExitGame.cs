using UnityEngine;
using System.Collections;
namespace menu
{
    namespace factory
    {
        namespace action
        {
            public class ExitGame : GenericAction
            {
                public override void doAction()
                {
                    Application.Quit();
                }
            }
        }
    }
}