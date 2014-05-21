using UnityEngine;
using System.Collections;

public class DestoryOnTouch : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        Destroy(col.collider.gameObject);
    }
}
