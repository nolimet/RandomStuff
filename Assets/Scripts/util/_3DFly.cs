using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/3DFly")]

public class _3DFly : MonoBehaviour
{
    private bool mouseRightDown;
    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (hor != 0 || ver != 0)
        {
           // rigidbody.isKinematic = false;
            if (Input.GetKeyDown(KeyCode.LeftShift))
                //transform.Translate((new Vector3(hor, 0, ver) * 12f) * Time.deltaTime);
                rigidbody.AddRelativeForce((new Vector3(hor, 0, ver) * 120f) * Time.deltaTime);
            else
                //transform.Translate((new Vector3(hor, 0, ver) * 6f) * Time.deltaTime);
                rigidbody.AddRelativeForce((new Vector3(hor, 0, ver) * 60f) * Time.deltaTime);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
           // rigidbody.isKinematic = true;
        }
    }
}
