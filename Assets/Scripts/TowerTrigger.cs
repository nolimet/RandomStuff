using UnityEngine;
using System.Collections;

public class TowerTrigger : MonoBehaviour {

	public bool gotTarget;
	// Use this for initialization

	void OnCollisionEnter(Collision col){
		Debug.Log ("Collision");

	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name=="Enemy"){
			gotTarget=true;
		}
		Debug.Log("TargetEntered");
	}

	/*void OnTriggerExit(Collider other){
		if(other.gameObject.name=="Enemy"){
			gotTarget=false;
			Debug.Log("TargetLeft");
		}
	}*/
}
