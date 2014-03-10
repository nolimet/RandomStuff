using UnityEngine;
using System.Collections;

public class GUISoundContorler : MonoBehaviour {

	public AudioFader Fader;
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button(new Rect(10+(25*0), 10, 25, 25), "+")){
			if(Fader.GitSec<=2){
				Fader.GitSec++;
			}}
		if (GUI.Button(new Rect(10+(25*0), 35, 25, 25), "-")){
			if(Fader.GitSec>=0){
				Fader.GitSec--;
			}}
		if (GUI.Button(new Rect(10+(25*1), 10, 25, 25), "+")){
			if(Fader.BassSec<=2){
				Fader.BassSec++;
			}}
		if (GUI.Button(new Rect(10+(25*1), 35, 25, 25), "-")){
			if(Fader.BassSec>=0){
				Fader.BassSec--;
			}}
		if (GUI.Button(new Rect(10+(25*2), 10, 25, 25), "+")){
			if(Fader.DrumsSec<=2){
				Fader.DrumsSec++;
			}}
		if (GUI.Button(new Rect(10+(25*2), 35, 25, 25), "-")){
			if(Fader.DrumsSec>=0){
				Fader.DrumsSec--;
			}}
		if (GUI.Button(new Rect(10+(25*3), 10, 25, 25), "+")){
			if(Fader.KeySec<=2){
				Fader.KeySec++;
			}}
		if (GUI.Button(new Rect(10+(25*3), 35, 25, 25), "-")){
			if(Fader.KeySec>=0){
				Fader.KeySec--;
			}}

		if (GUI.Button(new Rect(10, 60, 60, 25), "StopAll")){
				Fader.StopAll();
		}
	}
}
