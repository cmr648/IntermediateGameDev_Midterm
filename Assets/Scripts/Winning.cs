using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour {

	public Text Winning_Text; // creating a public text variable for our winning text
	public float Amount_To_Win; // creating ap ublic float to allow us to set the amount of points it takes to win. 
	public string Win_String; // creating a public string to set the text if the player wins
	public string Must_Keep_Playing_String; // creating a public string to tell the player if the have to keep playing
	public string Out_Of_Time_String; // creating a public string to tell the player when they are out of time

	public float Wait_Before_Scene; // creating a public variable to decide how long to wait before loading the new scene


	// Use this for initialization
	void Start () {
		Winning_Text.gameObject.SetActive (false); // setting our winning text gameobject to not be active at the start of the game

	}
	
	// Update is called once per frame
	void Update () {



		if (GetComponent<CountdownTimer> ().Minutes_Left <= 0 && GetComponent<CountdownTimer> ().Seconds_Left <= 0) { // checking to see if the player has completely run out of time
			GetComponent<CountdownTimer>().enabled = false; // disabling our countdown timer to set it to 0
			Winning_Text.text = Out_Of_Time_String; // setting our winning text to btell when the player has run out of time
			GetComponent<Driving_Controls>().enabled = false; // turning off our players driving controls
			Winning_Text.gameObject.SetActive (true); // turning on our winning text gameobject

		}
		
	}

	void OnTriggerEnter(Collider col){ // checking to see if the player has entered a trigger

		if (col.gameObject.tag == "Win_Trigger") { // checking to see if the trigger the player enters is the winning trigger

			if (GetComponent<Collect_Item> ().Total_Points >= Amount_To_Win) { // checking to see if the player has enough points to win
				Winning_Text.text = Win_String; // setting the winnint text to be our winning string
				StartCoroutine("Next_Level_Move");

			} else { // if the player does not have enough points to win
				Winning_Text.text = Must_Keep_Playing_String; // setting the winning text to be our must keep playing string.
			}

			GetComponent<Driving_Controls> ().enabled = false; // turning off our player movement
			Winning_Text.gameObject.SetActive (true); // turning on and displaying our winning text
		}


	}

	IEnumerator Next_Level_Move(){ // creating an IENumerator to move to our next scene
		yield return new WaitForSeconds (Wait_Before_Scene); // asking the computer to wait for an amount of seconds before moving to our new scene
		SceneManager.LoadScene ("Camera_Test"); // loading our new scene

	}
		
}
