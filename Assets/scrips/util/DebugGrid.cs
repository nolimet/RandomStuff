using UnityEngine;
using System.Collections;

public class DebugGrid : MonoBehaviour {

    public int height, width;

    public Vector2 A;
    public Vector2 B;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int k = 0;
        Vector2 ant = A + B;
        Debug.Log(ant);
	    for(int i = 0; i<height+1; i++)
        {
            Debug.DrawLine(new Vector3((-width / 2), i - (height / 2), k), new Vector3(width/2, i - (height / 2), k), Color.yellow);
        }
        for(int j = 0;j<width+1; j++)
        {
            Debug.DrawLine(new Vector3(j - (width / 2), height/-2, k), new Vector3(j - (width / 2), height/2, k), Color.red);
        }
        Debug.DrawLine(Vector3.zero, ant, Color.blue);
	}
}
