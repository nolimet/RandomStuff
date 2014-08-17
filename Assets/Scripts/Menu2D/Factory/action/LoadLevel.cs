using UnityEngine;
using System.Collections;
namespace menu
{
    namespace factory
    {
        namespace action
        {
            public class LoadLevel : GenericAction
            {
                string url;

                public void init(string _url){
                    url = _url;
                }

                public override void doAction()
                {
                    transform.parent.parent.gameObject.GetComponent<Loader>().SyncLoadLevel(url);
                } 
            }
        }
    }
}