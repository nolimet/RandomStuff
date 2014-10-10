using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace springs
{
    public class Spring : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> inRangeSprings  = new List<Transform>();

        void Start()
        {
            SpringStatics.springs.Add(this);
        }

        public void GetInRange(List<Spring> Springs)
        {
            inRangeSprings = new List<Transform>();
            Vector3 pos = transform.position;

            foreach (Spring spr in Springs)
            {
                
                if (Vector3.Distance(spr.transform.position, pos) < SpringStatics.maxDist && spr!=this)
                {
                    inRangeSprings.Add(spr.transform);
                }
            }
        }

        void Update()
        {
            foreach (Transform t in inRangeSprings)
            {
                if (t != null)
                    Debug.DrawLine(transform.position, t.position, Color.red);

                if (Vector3.Distance(t.position, transform.position) < SpringStatics.maxDist)
                {
                    Vector3 step = stepv2(t.position);
                    if (!checkNaN(step))
                        transform.Translate(stepv2(t.position) / 5f);
                }
            }
        }

        void OnDestroy()
        {
            SpringStatics.springs.Remove(this);
        }

        Vector3 stepv3(Vector3 value)
        {
            Vector3 lineLenght = transform.position - value;
            float dist = Vector3.Distance(transform.position,value);
            return new Vector3(lineLenght.x/dist,lineLenght.y/dist,lineLenght.z/dist);
        }

        bool checkNaN(Vector3 value)
        {
            if (float.IsNaN(value.x))
                return true;
            if (float.IsNaN(value.y))
                return true;
            if (float.IsNaN(value.z))
                return true;
            return false;
        }

        Vector3 stepv2(Vector3 value)
        {
            Vector3 lineLenght = transform.position - value;
            float dist = Vector3.Distance(transform.position, value);
            return new Vector3(lineLenght.x / dist, lineLenght.y / dist, 0);
        }
    }
}