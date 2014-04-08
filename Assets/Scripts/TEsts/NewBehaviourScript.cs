using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public Vector3 speed;
    //public Vector3 maxSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(speed);
	}
}
