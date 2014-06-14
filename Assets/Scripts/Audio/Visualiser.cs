using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Audio
{
    public class Visualiser : MonoBehaviour
    {
        [Range(0.01f, 100f)]
        public float audioDrawScale = 1f;
        [Range(16, 8192)]
        public int SpectrumSize;
        public List<Transform> cubes = new List<Transform>();

        public bool circle = true;
        bool cirlelastframe = false;

        float heightCap = 12f;
        float barWidth;
        // Use this for initialization
        void Start()
        {
            barWidth = 25.6f / SpectrumSize;
            for (int i = 0; i <SpectrumSize; i++)
            {
                GameObject cube = Instantiate(Resources.Load("SimpleCube"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                cube.name = "bar" + i;
                if (circle)
                {
                    GameObject pivot = new GameObject();
                    pivot.transform.parent = transform;
                    cube.transform.parent = pivot.transform;
                    cube.transform.rotation = Quaternion.Euler(0, 270,0);
                    pivot.name = "Pivot" + i;

                    UpdateRot(pivot.transform,cube.transform, i);
                }
                else
                {
                    cube.transform.parent = transform;
                }
                cubes.Add(cube.GetComponent<Transform>());
            }
            cirlelastframe = circle;
            Time.timeScale = 0.5f;
        }
        void Update()
        {

            float[] spectrum = audio.GetSpectrumData(SpectrumSize, 0, FFTWindow.BlackmanHarris);
            //Quaternion temprot;
            int i = 0;
            float channelSize = 0f;
            while (i < SpectrumSize)
            {
                if (circle != cirlelastframe)
                    UpdateRot(cubes[i].parent,cubes[i], i);
                channelSize = spectrum[i];
                //limiter
                if (spectrum[i] * audioDrawScale > 0.007f)
                {
                    if (spectrum[i] * audioDrawScale > heightCap)
                    {
                        channelSize = heightCap / audioDrawScale;
                    }
                    //   Debug.DrawLine(new Vector3(0,0,i/100f),new Vector3(0,spectrum[i]/audioDrawScale,i/100f),Color.yellow);
                    cubes[i].localScale = new Vector3(barWidth, channelSize * audioDrawScale + 0.01f, barWidth);
                    if (!circle)
                    {
                        cubes[i].position = new Vector3(0, (channelSize * audioDrawScale) / 2f, i * barWidth);
                    }
                    else
                    {
                        cubes[i].localPosition = new Vector3(0, (channelSize * audioDrawScale) / 2f, 0);
                    }
                }
                else
                {
                    cubes[i].localScale = new Vector3(barWidth, 0 * audioDrawScale + 0.01f, barWidth);
                    if (!circle)
                    {
                        cubes[i].position = new Vector3(0, (0 * audioDrawScale) / 2f, i * barWidth);
                    }
                    else
                    {
                        cubes[i].localPosition = new Vector3(0, (0 * audioDrawScale) / 2f, 0);
                    }
                }
                    i++;
            }
            cirlelastframe = circle;
        }
        void UpdateRot(Transform pivot,Transform cube ,int i)
        {
            float channelSize = 0f;
            if (circle)
            {
                pivot.transform.rotation = Quaternion.Euler((360f / SpectrumSize) * i, 0f, 0f);
                pivot.transform.localPosition = Vector3.zero;
                pivot.transform.Translate(0, 0, 2);
                pivot.transform.rotation = Quaternion.Euler((360f / SpectrumSize) * i + 90, 0f, 0f);
                cube.localScale = new Vector3(barWidth, channelSize * audioDrawScale + 0.01f, barWidth);
                cube.localPosition = new Vector3(0, (channelSize * audioDrawScale) / 2f, 0);
                heightCap = 5f;
            }
            else
            {
                
                heightCap = 12f;
                pivot.rotation = Quaternion.Euler(Vector3.zero);
                cube.localScale = new Vector3(barWidth, channelSize * audioDrawScale + 0.01f, barWidth);
                cube.position = new Vector3(0, (channelSize * audioDrawScale) / 2f, i * barWidth);
            }
        }
    }
}