using UnityEngine;
using System.Collections;
namespace Orbital
{
    public class BolCords : MonoBehaviour
    {
        [SerializeField]
        private Transform parentbody;
        [SerializeField]
        private float radius;
        [SerializeField]
        [Range(0,1f)]
        private float thera;
        [SerializeField]
        private float pheta;

        Vector3 posLast;

        void Start()
        {
            if (parentbody == null)
                parentbody = transform.parent;
            if (parentbody == null)
                Destroy(this);
            posLast = transform.position;
        }
        // Update is called once per frame
        void Update()
        {
            pheta += 0.01f;
            Debug.DrawLine(transform.position, posLast,Color.green,1f);
            posLast = transform.position;
            transform.position = getPos(radius, thera, pheta, parentbody.position);
            
        }

        public static Vector3 getPos(float @radius, float @thera, float @pheta, Vector3 parentBody)
        {
            Vector3 output = new Vector3();
            float x = parentBody.x + radius * Mathf.Sin(@thera) * Mathf.Cos(@pheta);
            float y = parentBody.y + radius * Mathf.Sin(@thera) * Mathf.Sin(@pheta);
            float z = parentBody.z + radius * Mathf.Cos(@pheta);

            output = new Vector3(y, x,z);
                return output;
        }
    }
}