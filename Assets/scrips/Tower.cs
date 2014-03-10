using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

	private List<Transform> targetsInRange = new List<Transform>();
	private Transform target;
	private float nextFireTime;
	private float turnSpeed = 1;

	void Update()
	{
		if(target !=null){
			Vector3 targetDir = new Vector3(target.position.x - transform.position.x,0f, target.position.z - transform.position.z);
			//Vector3 desiredRot = Vector3.RotateTowards(transform.forward,targetDir, Time.deltaTime * turnSpeed,0f);

			transform.rotation=Quaternion.FromToRotation(Vector3.forward,target.position);

			Debug.DrawLine (transform.position, target.position, Color.green);
			if(Time.time >= nextFireTime){
				Shoot();
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag =="Enemy"){
			Debug.Log ("targetEntered");
			targetsInRange.Add(other.gameObject.transform);
			target=targetsInRange[0];
		}
	}

	/*void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Enemy"){
			targetsInRange.Remove(other.gameObject.transform);
				Debug.Log(targetsInRange);
		}
	}*/

	void Shoot(){
		nextFireTime=Time.time+1;
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == "Enemy") {
			if (targetsInRange.Contains(col.gameObject.transform)) {
				targetsInRange.Remove(col.gameObject.transform);
				if (col.gameObject.transform == target) {
					if (targetsInRange.Count >= 1) {
						target = targetsInRange[0];
					} else {
						target = null;
					}
				}
			}
		}
	}
	/*public GameObject Trigger;
	public float Range = 3.5f;
	private TowerTrigger triggerscript;
	// Use this for initialization
	void Start () {
		triggerscript = Trigger.GetComponent<TowerTrigger>();
	}
	
	// Update is called once per frame
	void Update () {
		triggerscript = Trigger.GetComponent<TowerTrigger>();

		if(triggerscript.gotTarget){
			RaycastHit hit;
			float Closest=-1f;
			GameObject target;
			Vector3 p1 = transform.position;

			if (Physics.SphereCast(p1,Range, transform.forward, out hit, 0)){
				//if(hit.collider.gameObject.name=="Enemy"){
					float distanceToObstacle = hit.distance;
					if(distanceToObstacle<Closest){
						Closest=distanceToObstacle;
						target=hit.collider.gameObject;
						Debug.Log("GotTarget");
					}
				//}
			}
		}
	}*/
}
