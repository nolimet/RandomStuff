using UnityEngine;
using System.Collections;

public class infinitelinev2 : MonoBehaviour {

    [SerializeField]
    float x = 150;
    float yoff = 31.818f;

    Vector2 l;
    Vector2 AB = new Vector2(550,250);
	// Use this for initialization
	void Start () {
        float dist = Mathf.Sqrt((Mathf.Pow(AB.x, 2) + Mathf.Pow(AB.y, 2)));
        l = new Vector2(AB.x / dist, AB.y / dist);
	}

    Vector3 callp(float xd)
    {
        return new Vector3(x, l.y * x,0);
    }

    Vector3 call(float xd)
    {
        return new Vector3(-x, l.y * -x, 0);
    }

	// Update is called once per frame
	void Update () {
	    Debug.DrawLine(new Vector3(x,-10),new Vector3(x,10),Color.white,1f);
        print(call(x));
        print(callp(x));
        Vector3 a = call(x);
        Vector3 b = callp(x);
        Debug.DrawLine(a, b,Color.red,1f);
	}
}
