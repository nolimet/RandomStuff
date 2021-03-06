﻿using UnityEngine;
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
		private float speed = 0.1f; // Number Of Unity unites Orbited Per Frame
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

        Vector3 posLastframe;
        Color lineCol;

        void Start(){
            origin = transform.parent;
            radius = periaps;
            lineCol = DebugGrid.randomColor();
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

                if (angle < 180f)
                    updown = true;
                else
                    updown = false;

                if (updown)
                {
                    radius = periaps + (((appopaps - periaps) / 180f) * (angle % 180f));
                    Debug.DrawLine(transform.position, transform.position + (Vector3.up * 20),Color.blue);
                }
                else
                {
                    radius = appopaps - (((appopaps - periaps) / 180f) * (angle % 180f));
                    Debug.DrawLine(transform.position, transform.position + (Vector3.up * 20),Color.red);
                }
                //print((((appopaps - periaps) / 180f) * (angle % 180f)));
                //print(appopaps - periaps);
            }
            Vector3 pos = new Vector3();
            float rad = angle * (Mathf.PI / 180); // Converting Degrees To Radians
            angle += speed * Time.deltaTime;
            pos.x = origin.position.x + radius * Mathf.Cos(rad); // position The this Along x-axis
            pos.z = origin.position.z + radius * Mathf.Sin(rad); // position The this Along y-axis

            //this.rotation = (Math.atan2(this.y - origin.y, this.x - origin.x) * 180 / Math.PI);
            transform.position = pos;

            Debug.DrawLine(transform.position,posLastframe,lineCol,10f);

            posLastframe = transform.position;
        }
    }
}