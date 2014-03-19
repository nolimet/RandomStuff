using UnityEngine;
using System.Collections;

public class Saver : MonoBehaviour {
	public string test = "TEST TES TES ";
	public SaveData save;
	void OnGUI(){
		if (GUI.Button(new Rect(10, 10, 50, 50),"SAVE")){
			Debug.Log("SAVING");
			SaveLoad.Save("save.ctx");
		}
		//if (GUI.Button(new Rect(10, 10, 50, 50), btnTexture))
		//	Debug.Log("Load");
	}
	
}

