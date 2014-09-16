using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

    [SerializeField]
    private GameObject toLookat;

	void Update () {

        transform.LookAt(toLookat.transform.position);
       // Vector3 newRot = transform.rotation.eulerAngles;
       // newRot.y -= 180;

       // transform.rotation = Quaternion.Euler(newRot);
	}
}
