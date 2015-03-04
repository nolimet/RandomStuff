using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {

	private Animator animator;
	public bool dead;
	public float walk = 0;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");

		walk=ver;
		if(GetComponent<Rigidbody>().velocity.x<3 && GetComponent<Rigidbody>().velocity.z<3)
		{
			GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0,ver*10));
		}

		transform.Rotate(0,hor*0.5f,0);
		if(animator){
			animator.SetBool("death",dead);
			animator.SetFloat("walk", ver);
		}
	}
}
