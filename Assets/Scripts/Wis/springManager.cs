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
                SpringStatics.mouseDown = Input.GetMouseButton(1);
                foreach (Spring spr in SpringStatics.springs)
                {
                    if(spr!=null)
                       spr.GetInRange(SpringStatics.springs);
                }
                yield return new WaitForSeconds(0.05f);
            }
        }

        void OnGUI()
        {
            GUI.
            GUI.Box(new Rect(0, 0, 120, 50), "This is a title");
        }

    }
}
