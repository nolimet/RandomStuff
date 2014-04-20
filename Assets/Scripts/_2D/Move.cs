using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {


    bool g = false;
	// Update is called once per frame
	void Update () {
	    
	}

    public float floatHeight=1f;
    public float liftForce=1f;
    public float damping=0.1f;

    void FixedUpdate()
    {
        Vector2 linecastpos = new Vector2(transform.position.x,transform.position.y+1);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D hit = Physics2D.Linecast(pos,linecastpos);
      /*  if (hit != null)
        {
            float x = Input.GetAxis("Horizontal");     
            if (x != 0)
            {
                rigidbody2D.AddForce(new Vector2(x * 20f, 0));
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody2D.AddForce(new Vector2(0,200f));
            }*/
        if (hit != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            float heightError = floatHeight - distance;
            float force = liftForce * heightError - rigidbody2D.velocity.y * damping;
            rigidbody2D.AddForce(Vector3.up * force);
        }
    }
}
