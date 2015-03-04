using UnityEngine;
using System.Collections;

public class ArrayToTexture : MonoBehaviour {
    
    [Range(1,3),SerializeField]
    int NumbChannels = 2;
    void Start () {
        float[] array = new float[2048];
        int l = array.Length;
         //  print(l);
        for (int i = 0; i < l; i++)
        {
            array[i] = Random.Range(0, 255);
           // print(i);
        }

        GetComponent<Renderer>().material.mainTexture = intArray(array, NumbChannels, 32);
	}


    void Update()
    {
        Start();
    }
    public Texture2D intArray(float[] arr, int channelSize, int maxWidth = 32)
    {
        CodeProfiler.Begin("Array To Texture writer");
        if (channelSize > 3)
            channelSize = 3;
        int h = arr.Length/maxWidth/channelSize;
        int w = maxWidth;
        int index = 0;
        int l = arr.Length;
        Texture2D texture = new Texture2D(w, h, TextureFormat.ARGB32, false);
        float[] cols = new float[3];
        cols[0] = 0;
        cols[1] = 0;
        cols[2] = 0;

        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                for (int k = 0; k < channelSize; k++)
                {
                    if (index > l)
                        cols[k] = 255;
                    else
                        cols[k] = arr[index];

                    index++;
                }
                texture.SetPixel(j, i, NumberTocolor(cols[0], cols[1], cols[2], 0));
               // print("Color: " + intTocolor(cols[0], cols[1], cols[2], 0) + " At Index: " + index);
            }
        }

        texture.Apply(false);
        texture.anisoLevel = 0;
        texture.filterMode = FilterMode.Point;

        print("THeight " + texture.height + " TWidth " + texture.width);
        CodeProfiler.End("Array To Texture writer");
        return texture;
    }
    

    Color NumberTocolor(float r, float g, float b, float a)
    {
        return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
    }
}
