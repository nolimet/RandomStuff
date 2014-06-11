using UnityEngine;
using System.Collections;

namespace Orbital
{
    public class Orbitv2 :MonoBehaviour
    {
        [SerializeField]
        private Transform origin;
        [SerializeField]
		private float angle= 0; // The Initial Angle Orbiting Starts From
        [SerializeField]
		private float speed = 0.1f; // Number Of Pixels Orbited Per Frame
        [SerializeField]
		private float appopaps; // Orbiting Distance From Origin
        [SerializeField]
        private float periaps;
        [SerializeField]
        private bool updown = false;
        [SerializeField]
        private float radius;

        [SerializeField]
        private bool staticOrbit = true;

        void Start(){
            origin = transform.parent;
            radius = periaps;
        }

        public void Update()
        {
            if (angle >= 360f)
            {
                angle = 0;
            }
            if (!staticOrbit)
            {
                if (periaps > appopaps)
                {
                    float temp = periaps;
                    periaps = appopaps;
                    appopaps = temp;
                }

                if (radius < periaps)
                    updown = false;
                else if (radius > appopaps)
                    updown = true;


                if (updown)
                    radius -= (appopaps / 360) * speed;
                else
                    radius += (appopaps / 360) * speed;
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