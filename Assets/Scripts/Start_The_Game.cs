using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_The_Game : MonoBehaviour {

	public float Wait_Seconds; // creating a public float for when we should start the game
	public Text Beginning_Text; // creating a public text element for our begining text
	Driving_Controls Driving_Script; // creating a reference for our driving script
	CountdownTimer Game_Timer;  // creating a reference for our gametimer
	public GameObject Main_Camera; // creating a public reference to our main camera

	public AudioClip First_Beep; // creatinga  public audio clip reference for our first beep
	public AudioClip Second_Beep; // creating a second audio clip reference for our second beep

	// Use this for initialization
	void Start () {

		Driving_Script = GetComponent<Driving_Controls>(); // assiging our driving controls
		Game_Timer = GetComponent<CountdownTimer>(); // assiging our countdowntimer script
		StartCoroutine("Wait_Then_Start"); // starting our coroutuine to begin the game
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Wait_Then_Start(){ // creating an IEneumerator for when we should wait to start the game
		Driving_Script.enabled = false; // turning our driving controls on
		Game_Timer.enabled = false; // turning off our game timer
		Beginning_Text.text = "3"; // setting our beginning text
		AudioSource.PlayClipAtPoint(First_Beep,Main_Camera.transform.position); // creating an audio source just specifically to play a specific clip
		yield return new WaitForSeconds(Wait_Seconds); // asking our text to wait
		Beginning_Text.text = "2"; // setting our beginning text
		AudioSource.PlayClipAtPoint(First_Beep,Main_Camera.transform.position); // creating an audio source just specifically to play a specific clip
		yield return new WaitForSeconds(Wait_Seconds); // asking our text to wait
		Beginning_Text.text = "1"; // setting our beginning text
		AudioSource.PlayClipAtPoint(First_Beep,Main_Camera.transform.position); // creating an audio source just specifically to play a specific clip
		yield return new WaitForSeconds(Wait_Seconds); // asking our text to wait
		Beginning_Text.text = "Start"; // setting our beginning text
		AudioSource.PlayClipAtPoint(Second_Beep,Main_Camera.transform.position); // creating an audio source just specifically to play a specific clip
		Driving_Script.enabled = true; // setting our driving controls to be back on
		Game_Timer.enabled = true; // setting our countdown timer to be back on
		yield return new WaitForSeconds(Wait_Seconds); // asking our text to wait
		Beginning_Text.enabled = false; // turning our begging text off
	}
}
