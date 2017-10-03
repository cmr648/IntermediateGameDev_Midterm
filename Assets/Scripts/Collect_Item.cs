using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect_Item : MonoBehaviour {

	public float Point_Increase; // the amount we will increase points by if an item is collected
	public float Total_Points; // the total points the player currently has
	public Text Point_Text; // creatinga  public variable for the text that will show points

	// Use this for initialization
	void Start () {
		Total_Points = 0; // setting the total points to 0 at the start of a game
	}
	
	// Update is called once per frame
	void Update () {

		Point_Text.text = "Points: " + Total_Points;
		
	}

	void OnTriggerEnter(Collider col){ // checking to see if an object is collided with 

		if (col.gameObject.tag == "Point") { // checking to see if the object collided with is tagged as point
			Destroy (col.gameObject); // destroying the gameobject that is collected
			Total_Points += Point_Increase;
		}


	}
}
