using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush_Button_Fade : MonoBehaviour {

	public KeyCode Next_Scene_Button; // creating a custom keycode for our next button
	Fader_Script Fade_Script; // creatinga  costum fade script

	// Use this for initialization
	void Start () {
		Fade_Script = GetComponent<Fader_Script> (); // getting the faderscript from our camera
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (Next_Scene_Button)) { // checking to see if our next scene button has been pressed 
			Fade_Script.Can_Fade_Out = true; // setting our fade out to be equal to true

		}
		
	}
}
