﻿using UnityEngine;
using System.Collections;

public class SlowFade : MonoBehaviour {

	private float duration = 5.0f;

 

    // Update is called once per frame

    void Update () {

        Color textureColor = GetComponent<Renderer>().material.color;

        textureColor.a = Mathf.PingPong(Time.time, duration) / duration;
		//Debug.Log (textureColor.a);

        GetComponent<Renderer>().material.color = textureColor;

    }
}
