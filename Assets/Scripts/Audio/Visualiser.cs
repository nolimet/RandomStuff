using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Visualiser : MonoBehaviour
{

    AudioSource tests;
    public float audioDrawScale = 1f;
    [Range(64,1024)]
    public int SpectrumSize;
    private List<Transform> cubes = new List<Transform>();
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
        float[] spectrum = audio.GetSpectrumData(SpectrumSize, 0, FFTWindow.BlackmanHarris);
        int i = 0;
        while (i < SpectrumSize)
        {
            Debug.DrawLine(new Vector3(0,0,i/100f),new Vector3(0,spectrum[i]/audioDrawScale,i/100f),Color.yellow);
            cubes[i].localScale = new Vector3(0.2f, spectrum[i] / audioDrawScale + 0.2f, 0.2f);
            cubes[i].position = new Vector3(0, (spectrum[i] / audioDrawScale) / 2f, i / 5f);
            i++;
        }
    }
}