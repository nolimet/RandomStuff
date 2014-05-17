using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Audio
{
    public class Visualiser : MonoBehaviour
    {
        [Range(0.01f, 100f)]
        public float audioDrawScale = 1f;
        [Range(16, 1024)]
        public int SpectrumSize;
        public List<Transform> cubes = new List<Transform>();
        // Use this for initialization
        void Start()
        {
            bool b = true; ;
            for (int i = SpectrumSize; i > 0; i--)
            {
                GameObject cube = Instantiate(Resources.Load("SimpleCube"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                cube.name = "cube" + i;
                cube.transform.parent = transform;
                b = !b;
                cubes.Add(cube.GetComponent<Transform>());
            }
        }
        void FixedUpdate()
        {
            float barWidth = 25.6f / SpectrumSize;
            float[] spectrum = audio.GetSpectrumData(SpectrumSize, 0, FFTWindow.BlackmanHarris);
            int i = 0;
            float channelSize = 0f;
            while (i < SpectrumSize)
            {
                channelSize = spectrum[i];
                if (spectrum[i] * audioDrawScale > 12f)
                {
                    channelSize = 12f / audioDrawScale;
                }
                //   Debug.DrawLine(new Vector3(0,0,i/100f),new Vector3(0,spectrum[i]/audioDrawScale,i/100f),Color.yellow);
                cubes[i].localScale = new Vector3(barWidth, channelSize * audioDrawScale + 0.01f, barWidth);
                cubes[i].position = new Vector3(0, (channelSize * audioDrawScale) / 2f, i * barWidth);
                i++;
            }
        }
    }
}