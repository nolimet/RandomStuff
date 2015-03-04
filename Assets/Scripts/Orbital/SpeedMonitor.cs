using UnityEngine;
using System.Collections;

public class SpeedMonitor : MonoBehaviour {

	public GameObject ToMonitor;
	//private GUIText guitext;
	void Start(){

	}

	void Update(){
		GetComponent<GUIText>().text="VelocityX: " + ToMonitor.GetComponent<Rigidbody>().velocity.x + "\nVelocityY: " + ToMonitor.GetComponent<Rigidbody>().velocity.y + "\nVelocityZ: " + ToMonitor.GetComponent<Rigidbody>().velocity.z;
	}
}
