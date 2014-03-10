
using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public Transform[] Targets;
	private int targetIndex=0;
	public float speed;
	public float rotationSpeed;
	public float accurcy=0.1f;
	// Use this for initialization
	void Start () {
		//target=Target1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Targets.Length<=0){
			return;
		}
		// sta ik op target

		//distance  target
		if(Vector3.Distance(transform.position,Targets[targetIndex].position)<accurcy){
			targetIndex++;
			if(targetIndex>=Targets.Length){
				targetIndex=0;
			}
		}
		// beweeg richting waypoint

			//transform.LookAt(Targets[targetIndex].position);
		Vector3 targetDist = Targets[targetIndex].position - transform.position;
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(targetDist),rotationSpeed *Time.deltaTime);
		transform.Translate(Vector3.forward*speed*Time.deltaTime);
	}
}
