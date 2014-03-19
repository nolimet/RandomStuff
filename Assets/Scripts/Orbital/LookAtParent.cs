using UnityEngine;
using System.Collections;
namespace Orbital
{
    public class LookAtParent : Orbit
    {
        void Update()
        {
            transform.LookAt(parentPos.position);
        }
    }
}
