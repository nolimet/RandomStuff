using UnityEngine;
using System.Collections;
namespace Menu
{
    namespace Rotating
    {
        public class MenuObject : MonoBehaviour
        {
            GameObject pivot;
            public int IndexNumb;
            public void SetPos(Quaternion rot, float distsCenter, int _IndexNumb)
            {
                pivot = new GameObject("Pivot for "+name);
                pivot.transform.parent = transform.parent;
                transform.parent = pivot.transform;
                transform.localPosition = Vector3.zero;
                pivot.transform.localPosition = Vector3.zero;
                pivot.transform.rotation = rot;
                transform.Translate(0, 0, distsCenter);
                name=name + "[" +_IndexNumb +  "]";
            }
        }
    }
}
