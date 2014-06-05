using UnityEngine;
using System.Collections;

public class InfiniteLine : MonoBehaviour {


    [SerializeField]
    private Transform Object1;

    [SerializeField]
    private Transform Object2;

    [SerializeField]
    Vector3 posObj1;

    void Start()
    {
        Object1.name = "Object1";
        Object2.name = "Object2";
    }
    void Update()
    {

        Object1.position = posObj1;
        Vector3 dir = Object1.position - Object2.position;
        Debug.Log(dir);
        Debug.DrawLine(Object1.position, Object2.position);
        Debug.DrawLine(Object1.position, dir * 20f + Object1.position);
        Debug.DrawLine(Object2.position, -dir * 20f + Object2.position);
    }

    void OnGUI()
    {
        posObj1 = new Vector3(-(GUI.VerticalSlider(new Rect(20, 20, 20, 100), posObj1.x-5, 0, 10f)),GUI.VerticalSlider(new Rect(45, 20, 20, 100), posObj1.y, 0, 10f),0);
    }
}
