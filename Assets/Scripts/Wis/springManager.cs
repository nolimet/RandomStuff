using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace springs
{
    public class springManager : MonoBehaviour
    {

        [SerializeField]
        private float MaxDist;

        void Update()
        {
            SpringStatics.maxDist = MaxDist;
        }
        void Start()
        {
            StartCoroutine(SpringGridUpdate());
        }

        IEnumerator SpringGridUpdate()
        {
            while (Application.isPlaying)
            {
                foreach (Spring spr in SpringStatics.springs)
                {
                    if(spr!=null)
                       spr.GetInRange(SpringStatics.springs);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }

    }
}
