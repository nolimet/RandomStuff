using UnityEngine;
using System.Collections;

public class SpriteHandler : MonoBehaviour {

	private int delay;
	
	//public int nrOfColums;
	//public int nrOfRows;
	
	//public int NrOfCells;
	//public float Fps;
	
	//public int startAtCollum;
	//public int startAtRow;
	// Update is called once per frame
	
	public void Animate (int nrOfColums, int nrOfRows, int startAtColum, int startAtRow,int NrOfCells,int Fps) {

		int index = (int) (Fps*Time.time);
		index = index % NrOfCells;
			
		float sizeX = 1f /nrOfColums;
		float sizeY =1f / nrOfRows;
		Vector2 size = new Vector2 (sizeX,sizeY);
		
		float vindex = index/nrOfColums;
		float uindex = index%nrOfColums;
		
		float OffSetX = size.x*(uindex+startAtColum);
		float OffSetY =size.y*(vindex+startAtRow);
		Vector2 OffSet = new Vector2 (OffSetX,OffSetY);
		
		Debug.Log ("vindx " + vindex + " uindx " + uindex);
		//set size
		
		GetComponent<Renderer>().material.SetTextureScale("_MainTex",size);
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex",OffSet);
		
	}
}
