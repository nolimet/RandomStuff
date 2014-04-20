using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    Transform StartPoint;

    public Transform[] Menus;
    public Menu.Button[] buttons;

	// Use this for initialization
	void Start () {
        StartPoint = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
