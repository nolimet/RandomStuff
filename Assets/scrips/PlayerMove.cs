using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed;
	private SpriteHandler animeate;
	
	void Start()
	{
		animeate = GetComponent<SpriteHandler>();	
	}
	// Update is called once per frame
	void Update () {
		
		
		float x = -Input.GetAxis("Horizontal");
		if(x !=0)
		{
			animeate.Animate(5,2,0,0,10,30);	
		}
		Vector2 move = new Vector2 (x, 0f);
		transform.Translate(-move * speed *Time.deltaTime);
		
	}
}
