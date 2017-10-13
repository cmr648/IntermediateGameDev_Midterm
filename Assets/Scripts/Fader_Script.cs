using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader_Script : MonoBehaviour {

	public string Next_Level; // creating a public string reference for the next level we want to load
	public Image Fade_In_Fader; // creating a public image reference for the fader we want to fade in
	public Image Fade_Out_Fader; // creating a public image for our fade out fader
	public Color No_Alpha; // creating a public color reference to our no alpha color
	public Color All_Alpha; // creating a public color reference to our all alpha color
	public float Time_To_Fade; // creating a public float for the amount of time it should take to fade in

	public bool Can_Fade_Out; // setting a bool to see if the player can fade out


	// Use this for initialization
	void Start () {

		Fade_In_Fader.color = All_Alpha; // setting our fade in color
		Fade_Out_Fader.color = No_Alpha; // setting our fade out color

	}
	
	// Update is called once per frame
	void Update () {
		Fade_In_Fader.color = Color.Lerp (Fade_In_Fader.color, No_Alpha, Time.deltaTime*Time_To_Fade); // fading in our fade in fader 

		if (Can_Fade_Out == true) { // checking to see if the scene can fade out

			Fade_Out (); // fading out of our scene and changing scnes
		}

	}

	 void Fade_Out(){
		Fade_Out_Fader.color = Color.Lerp (Fade_Out_Fader.color, All_Alpha, Time.deltaTime * Time_To_Fade); // fading out our fade out color

		if (Fade_Out_Fader.color == All_Alpha) { // checking to see if the color of fade out matcches
			SceneManager.LoadScene (Next_Level); // loading our next level

		}

	}
}
