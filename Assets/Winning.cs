using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winning : MonoBehaviour {

	public Text Winning_Text; // creating a public text variable for our winning text
	public float Amount_To_Win; // creating ap ublic float to allow us to set the amount of points it takes to win. 
	public string Win_String; // creating a public string to set the text if the player wins
	public string Must_Keep_Playing_String; // creating a public string to tell the player if the have to keep playing

	// Use this for initialization
	void Start () {
		Winning_Text.gameObject.SetActive (false); // setting our winning text gameobject to not be active at the start of the game

	}
	
	// Update is called once per frame
	void Update () {

		if (GetComponent<Collect_Item> ().Total_Points >= Amount_To_Win) { // checking to see if the player has enough points to win
			Winning_Text.text = Win_String; // setting the winnint text to be our winning string

		} else { // if the player does not have enough points to win
			Winning_Text.text = Must_Keep_Playing_String; // setting the winning text to be our must keep playing string.
		}
		
	}

	void OnTriggerEnter(Collider col){ // checking to see if the player has entered a trigger

		if (col.gameObject.tag == "Win_Trigger") { // checking to see if the trigger the player enters is the winning trigger
			
			Winning_Text.gameObject.SetActive (true); // turning on and displaying our winning text
		}

		if (col.gameObject.tag == "Win_Trigger" && GetComponent<Collect_Item>().Total_Points >= Amount_To_Win) { // checking to see if the trigger the player enters is the winning trigger and the player has the right amound ofpoints and there velocity = 0
			GetComponent<Driving_Controls>().enabled = false; // turning off our player movement if the player wins

		}

	}

	void OnTriggerExit(Collider col){ // checking to see if the player has left a trigger


		if (col.gameObject.tag == "Win_Trigger") { // checking to see if the trigger the player enters is the winning trigger

			Winning_Text.gameObject.SetActive (false); // turning off  our winning text
		}

	}
}
