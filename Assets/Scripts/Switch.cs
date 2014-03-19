using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
	
	int str = 1;
	// Use this for initialization
	void Start () {
		switch(str){
			case 0:
				Debug.Log("test");
				break;
		case 1:
			Debug.Log("test2");
			break;
		}
	}
}
