using UnityEngine;
using System.Collections;

namespace Orbital
{
    public class Orbitv2 :MonoBehaviour
    {
        public Transform origin;
		public float angle= 0; // The Initial Angle Orbiting Starts From
		public float speed = 0.1f; // Number Of Pixels Orbited Per Frame
		public float radius = 30; // Orbiting Distance From Origin
		public bool losegravity;

        void Start(){
            origin = transform.parent;
        }

        public void Update()
        {
            if (angle >= 360f)
            {
                angle = 0;
            }
            Vector3 pos = new Vector3();
            float rad = angle * (Mathf.PI / 180); // Converting Degrees To Radians
            angle += speed;
            pos.x = origin.position.x + radius * Mathf.Cos(rad); // position The this Along x-axis
            pos.z = origin.position.z + radius * Mathf.Sin(rad); // position The this Along y-axis

            //this.rotation = (Math.atan2(this.y - origin.y, this.x - origin.x) * 180 / Math.PI);
            transform.position = pos;
        }
    }
}