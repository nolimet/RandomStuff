﻿using UnityEngine;
using System.Collections;

public class LoadLevelOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.LoadLevel(1);
        Destroy(this);
	}

}
