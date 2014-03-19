using UnityEngine;
using System.Collections;

public class enumScript : ChangeColour {
	
	enum Direction{
		Left,
		Right,
		Up,
		Down
	}
	
	enum Weapons{
		Pistol,
		SubmachineGun,
		AsaultRifle,
		Sniper,
		Granade,
		C4,
		RocketLauncher,
		Knife
	}
	
	private Direction dir;
	private Weapons weap;

	void Start(){
		dir = ((Direction)2);
		
		Debug.Log(dir);
	}
	
	void Update(){
		
			if(Input.GetKeyDown(KeyCode.Alpha1))
			{
				weap = Weapons.Pistol;
			}
			else if(Input.GetKeyDown(KeyCode.Alpha2))
			{
				weap = Weapons.SubmachineGun;
			}
			else if(Input.GetKeyDown(KeyCode.Alpha3))
			{
				weap = Weapons.AsaultRifle;
			}
			else if(Input.GetKeyDown(KeyCode.Alpha4))
			{
				weap = Weapons.Sniper;
			}
			else if(Input.GetKeyDown(KeyCode.Alpha5))
			{
				weap = Weapons.Granade;
			}
			else if(Input.GetKeyDown(KeyCode.Alpha6))
			{
				weap = Weapons.C4;
			}
			else if(Input.GetKeyDown(KeyCode.Alpha7))
			{
				weap = Weapons.RocketLauncher;
			}
			else if(Input.GetKeyDown(KeyCode.Alpha8))
			{
				weap = Weapons.Knife;
			}
		
		
		if(Input.anyKeyDown)
		{
			Debug.Log(weap);
			switch(weap)
			{
			case Weapons.Pistol:
				changeColour(255,0,0);
				break;
				
			case Weapons.SubmachineGun:
				changeColour(0,255,0);
				break;
				
			case Weapons.AsaultRifle:
				changeColour(0,0,255);
				break;
				
			case Weapons.Sniper:
				changeColour(255,255,0);
				break;
				
			case Weapons.Granade:
				changeColour(255,0,255);
				break;
				
			case Weapons.C4:
				changeColour(0,255,255);
				break;
				
			case Weapons.RocketLauncher:
				changeColour(125,0,125);
				break;
				
			case Weapons.Knife:
				changeColour(125,125,0);
				break;
				
			default:
				changeColour(255,255,255);
				break;
			}
		}
	}
	

}
