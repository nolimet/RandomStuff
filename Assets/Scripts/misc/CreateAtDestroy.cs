using UnityEngine;
using System.Collections;

public class CreateAtDestroy : MonoBehaviour {
	
	public GameObject Created;
	// Use this for initialization
	void OnDestroy()
	{
		Instantiate(Created,transform.position,transform.rotation);	
	}
}
