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
        
            GUI.Box(new Rect(0, 0, 200, 50), "Minimal distance = " + MaxDist.ToString());
            MaxDist = GUI.HorizontalSlider(new Rect(25, 20, 100, 20), MaxDist, 0.1f, 20);
        }

    }
}
