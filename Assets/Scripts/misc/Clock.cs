using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {

    [SerializeField]
    Transform MiliSeconds,Seconds, Minuts, Hours;

    bool stopWatch;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        MiliSeconds.rotation = GetRot(DateTime.Now.Millisecond, 1000);
        Seconds.rotation = GetRot(DateTime.Now.Second, 60);
        Minuts.rotation = GetRot(DateTime.Now.Minute, 60);
        Hours.rotation = GetRot(DateTime.Now.Hour, 12);
	}

    Quaternion GetRot(float Value, float Scale)
    {
        float used = -(Value * 360f) / Scale;

        return (Quaternion.Euler(0, 0, used));
    }
}
