using UnityEngine;
using System.Collections;
namespace menu
{
    namespace factory
    {
        namespace action
        {
            public class GenericAction : MonoBehaviour
            {
                public virtual void doAction()
                {
                    Debug.LogWarning("EmptyActionCalled");
                }
            }
        }
    }
}
