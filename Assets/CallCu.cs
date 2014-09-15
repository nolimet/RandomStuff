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
        if(tps!=0)
         t += Time.deltaTime;

        if (tps!=0 && t < 1)
            return;

        Calculate();
        t = 0;
        TotalFuel -= Consumption*tps;
    }
    void Calculate()
    {

        float t = (TotalFuel / Consumption) / tps;
        float fms = Mathf.FloorToInt((t * 1000) % 1000);

        float fs = Mathf.FloorToInt(t % 60);
        // print(s);
        float fm = Mathf.FloorToInt(t / 60 % 60);
        //print(m);
        float fh = Mathf.FloorToInt((t / 3600) % 24);
        //  print(h);
        float d = Mathf.FloorToInt((t / 3600 / 24));
        // print(d);

        string ms;
        string s;
        string m;
        string h;

        if (fms == 0)
            ms = "";
        else if (fms < 10)
            ms = "000" + fms;
        else if (fms < 100)
            ms = "00" + fms;
        else
            ms = "" + fms;

        if (fs < 10)
            s = "0" + fs;
        else
            s = "" + fs;

        if (fm < 10)
            m = "0" + fm;
        else
            m = "" + fm;

        if (fh < 10)
            h = "0" + fh;
        else
            h = "" + fh;

        
        if (d == 0 && fh == 0 && fm == 0)
            time = " " + s + ":" + ms;
        else if (d == 0 && fh == 0)
            time = " " + m + ":" + s + ":" + ms;
        else if (d == 0)
            time = " " + ":" + h + ":" + m + ":" + s + ":" + ms;
        else
            time = " " + d + ":" + h + ":" + m + ":" + s + ":" + ms;

    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 50), time);
    }
}
