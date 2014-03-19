using UnityEngine;
using System.Collections;
namespace Orbital
{
    public class LockAxis : MonoBehaviour
    {

        public bool LockX;
        public bool LockY;
        public bool LockZ;

        private float lockedX;
        private float lockedY;
        private float lockedZ;

        // Update is called once per frame
        void Start()
        {

        }
        void Update()
        {
            Vector3 TempPos = transform.position;

            if (LockX)
            {
                TempPos.x = lockedX;
            }
            else
            {
                lockedX = TempPos.x;
            }
            if (LockY)
            {
                TempPos.y = lockedY;
            }
            else
            {
                lockedX = TempPos.y;
            }
            if (LockZ)
            {
                TempPos.z = lockedZ;
            }
            else
            {
                lockedZ = TempPos.z;
            }
        }
    }
}
