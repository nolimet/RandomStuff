using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orbit : StellarObject
{

    StellarObject parentobj;
    Transform parentPos;
    private List<GameObject> attracionPoints = new List<GameObject>();
    const float gravitationalConstant = 0.5f;
    // Use this for initialization
    void Start()
    {
        Object[] objects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in objects)
        {
            if (go.gameObject.tag == "AttractionPoint")
            {
                attracionPoints.Add(go);
            }
        }
       

        GetClostestAttPoint();
    }

    void FixedUpdate()
    {
        GetClostestAttPoint();
        if (parentPos != null)
        {
            Vector3 diff = parentPos.position - transform.position;
            Vector3 direction = diff.normalized;
            float gravitationalForce = (parentobj.mass * mass * gravitationalConstant) / diff.sqrMagnitude;
            rigidbody.AddForce(direction * gravitationalForce);
        }
    }
    void Update()
    {
        if (parentPos != null)
        {
            Debug.DrawLine(transform.position, (rigidbody.velocity / 5f) + transform.position, Color.blue);
            Debug.DrawLine(transform.position, parentPos.position, Color.red);
        }

    }

    void GetClostestAttPoint()
    {
      

        float shortest = Mathf.Infinity;
        float l = attracionPoints.Count;
        for (int i = 0; i < l; i++)
        {
            float dist = Vector3.Distance(attracionPoints[i].transform.position, transform.position);
            //Debug.DrawLine(transform.position, attracionPoints[i].transform.position);
            if (dist > 0 && dist < shortest)
            {
                shortest = dist;
                parentobj = attracionPoints[i].GetComponent<StellarObject>();
                parentPos = attracionPoints[i].GetComponent<Transform>();

            }
            else if (dist < 0 && dist > shortest)
            {
                shortest = dist;
                parentobj = attracionPoints[i].GetComponent<StellarObject>();
                parentPos = attracionPoints[i].GetComponent<Transform>();
            }
        }
    }
}
