using UnityEngine;
using System.Collections;

public class Soundcontroler : MonoBehaviour {

	private bool Playing = false;
	private float volume = 0f;
	private AudioSource source;
		
	void Start(){
		source=GetComponent<AudioSource>();
	}

	void Update(){
		if(volume==-1){
			return;
		}
		if(volume<=1f&&Playing){
			volume+=Time.deltaTime*4f;
			source.volume=volume;
			//Debug.Log(volume);
		}
		if(volume>=0&&Playing==false){
			volume-=Time.deltaTime*4f;
			source.volume=volume;
			//Debug.Log(volume);
		}
		if(volume<0f&&volume!=-1){
			source.Stop();
			volume=-1;
			Debug.Log("stoped Audio");
		}
	}

	public void Play() {
		Playing=true;
		source.Play();
		volume=0f;
	}

	public void Stop(){
		Playing=false;
	}

	public void StopImidiate(){
		Playing=false;
		source.Stop();
		volume=1f;
	}
}
