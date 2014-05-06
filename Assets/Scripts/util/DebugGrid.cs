using UnityEngine;
using System.Collections;

public class DebugGrid : MonoBehaviour {

    public int height, width;

    public Vector2 A;
    public Vector2 B;
    public bool _altMode;
    public bool ALtMode{
        set{
            _ALtMode = value;
            points[3].gameObject.SetActive(value);
            points[4].gameObject.SetActive(value);
            points[5].gameObject.SetActive(value);
            }
        get
        {
            return _ALtMode;
        }
    }
   
    public Vector2 C;

    float delay=1f;

    public Transform[] points;

	// Use this for initialization
	void Start () {
        points[0].name = "A";
        points[1].name = "B";
        points[2].name = "C";
        points[3].name = "AB";
        points[4].name = "BC";
        points[5].name = "CA";
	}
	
	// Update is called once per frame
	void Update () {
        _ALtMode = AltMode;
        int k = 0;
        Vector2 ant = A + B;
        Debug.Log(ant);
        if (delay >= 1)
        {
            for (int i = 0; i < height + 1; i++)
            {
                Debug.DrawLine(new Vector3((-width / 2), i - (height / 2), k), new Vector3(width / 2, i - (height / 2), k), Color.white, 1f);
            }
            for (int j = 0; j < width + 1; j++)
            {
                Debug.DrawLine(new Vector3(j - (width / 2), height / -2, k), new Vector3(j - (width / 2), height / 2, k), Color.gray, 1f);
            }
            delay = 0;
        }
        delay += Time.deltaTime;
        if (!_ALtMode)
        {
            Debug.DrawLine(Vector3.zero, ant, Color.blue);
            Debug.DrawLine(Vector3.zero, A, Color.green);
            Debug.DrawLine(Vector3.zero, B, Color.magenta);
            Debug.DrawLine(A, ant, Color.red);
            Debug.DrawLine(B, ant, Color.red);
            points[0].position = A;
            points[1].position = B;
            points[2].position = ant;
        }
        else
        {
            //Setting positions
            points[0].position = A;
            points[1].position = B;
            points[2].position = C;
            points[3].position = A * 0.5f + B * 0.5f;
            points[4].position = B * 0.5f + C * 0.5f;
            points[5].position = C * 0.5f + A * 0.5f;

            //Drawing lines

            //A
            Debug.DrawLine(points[0].position, points[3].position, Color.blue); 
            Debug.DrawLine(points[0].position, points[4].position, Color.red); 
            Debug.DrawLine(points[0].position, points[5].position, Color.magenta); 
            //B
            Debug.DrawLine(points[1].position, points[3].position, Color.blue); 
            Debug.DrawLine(points[1].position, points[4].position, Color.yellow); 
            Debug.DrawLine(points[1].position, points[5].position, Color.red); 
            //C
            Debug.DrawLine(points[2].position, points[3].position, Color.red); 
            Debug.DrawLine(points[2].position, points[4].position, Color.yellow); 
            Debug.DrawLine(points[2].position, points[5].position, Color.magenta);

            //renaming
            points[0].name = "A" + A;
            points[1].name = "B" + B;
            points[2].name = "C" + C;
        }
	}
    public static Color randomColor()
    {
        // float numb = 0.0039215686274509803921568627451f;
        Color output = new Color();
        output.b = 1 * Random.value;
        output.g = 1 * Random.value;
        output.r = 1 * Random.value;
        output.a = 1;

        return output;
    }
}
