using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public Text Timer_Text; // creating a public text object for our timer text;

	public float Minutes_Left; // creatinga  public float to set the amount of minutes
	public float Seconds_Left; // creating a float for the amount of seconds left
	float milliseconds = 0; // creating a float for milliseconds

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (milliseconds <= 0) { // checking to see if the player has milliseconds left
			if (Seconds_Left <= 0) { // checking to see if the pplayer has seconds left in a minute
			
				Minutes_Left--; // subtracting a minute from our timer
				Seconds_Left = 59; // ressetting the maount of seconds

			} else if (Seconds_Left > 0) { // checking to see if the player has more than 0 seconds left
				Seconds_Left --; // subtracting a second from our timer

			}

			milliseconds = 100; // resetting our milliseconds to 100

		}
			

		milliseconds -= Time.deltaTime * 100; // subtracting time from our millieseconds variable


		Timer_Text.text = "Time Left: " + string.Format ("{0}:{1:00}", Minutes_Left, Seconds_Left); // setting our timer text to be equal to the amount of time we have left




	}
}
