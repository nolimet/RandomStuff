    using UnityEngine;
using System.Collections;

public class CallCu : MonoBehaviour {

    [SerializeField]
    float Consumption;
    [SerializeField]
    float TotalFuel;
    [SerializeField]
    int tps;

    string time;
    [SerializeField]
    float t;
    void Start()
    {

        Calculate();
    }

    void Update()
    {
        t += Time.deltaTime;

        if (t < 1 / tps)
            return;

        Calculate();
        t = 0;
        TotalFuel -= Consumption;
    }
    void Calculate()
    {
        float t = (TotalFuel / Consumption)/tps;
        float s = Mathf.FloorToInt(t % 60);
       // print(s);
        float m = Mathf.FloorToInt(t / 60 % 60);
        //print(m);
        float h = Mathf.FloorToInt((t / 3600) % 24);
      //  print(h);
        float d = Mathf.FloorToInt((t /3600 /24));
       // print(d);

        time = " " + d + ":" + h + ":" + m + ":" + s;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 50), time);
    }
}
