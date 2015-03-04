using UnityEngine;
using System.Collections;

namespace menu
{
    public class BlinkingText : MonoBehaviour
    {

        Material m;
        [SerializeField]
        [Range(0, 1f)]
        private float opacity =0.8f;

        [SerializeField]
        [Range(0, 10f)]
        private float blinkSpeed =4f;
        void Start()
        {
            m = GetComponent<TextMesh>().GetComponent<Renderer>().material;
        }

        // Update is called once per frame
        void Update()
        {
            m.color = new Color(1, 1, 1, Mathf.PingPong(Time.time / blinkSpeed, opacity) + (1f - opacity));
        }
    }
}