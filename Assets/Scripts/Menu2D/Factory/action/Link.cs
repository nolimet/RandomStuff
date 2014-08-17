using UnityEngine;
using System.Collections;
namespace menu
{
    namespace factory
    {
        namespace action
        {
            public class Link : GenericAction
            {
                string Url;
                public void init(string url)
                {
                    Url = url;
                }
                public override void doAction()
                {
                    Application.OpenURL(Url);
                }
            }
        }
    }
}
