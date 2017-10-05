using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect_Item : MonoBehaviour {

	public float Point_Increase; // the amount we will increase points by if an item is collected
	public float Total_Points; // the total points the player currently has
	public Text Point_Text; // creatinga  public variable for the text that will show points

	public float Point_Decrease; // the amount we will increase points by if the player goes to a bad area
	bool Player_In_Bad_Driving_Zone; // checking to see if the player is within a bad driving zone
	float milliseconds; // a float to keep track of milliseconds
	public float Decrease_Time; // creating a public float to speed up the time something decreases at

	public Slider Good_Will_Slider; // creating a public variable for our good will slider

	GameObject[] Point_Objects; // creatinga  game object for an array of all objects that give points
	float Number_Of_Point_Objects = 0; // crating a float to store amount of point objects

	public Color Player_Doing_Well; // creating a public color for when our player is doing well
	public Color Player_Doing_Neutral; // creating a public color for when our player is doing nuetra
	public Color Player_Doing_Bad; // creating a public color for when our player is doing bad

	public Image Slider_Fill; // creatinga  public gameobject to change the color of the fill of our slider
	public Image Slider_Loading; // creating a public gameobject for our slider filling up

	// Use this for initialization
	void Start () {
		Total_Points = 0; // setting the total points to 0 at the start of a game
		Player_In_Bad_Driving_Zone = false; // start with the player not in a bad driving zone

		milliseconds = 1000; // setting our milliseconds to be equal to 1000

		Point_Objects = GameObject.FindGameObjectsWithTag ("Point"); // adding all the point objects to our array
		Good_Will_Slider.maxValue = Point_Objects.Length * Point_Increase; // setting the max valu of our slider to be the total amount of points possible within the game
		Good_Will_Slider.minValue = -Good_Will_Slider.maxValue; // setting the minimum value of our slider to be the opposite of what the maxium value is


	}
	
	// Update is called once per frame
	void Update () {

		Color_Of_Slider ();

		Good_Will_Slider.value = Mathf.Lerp (Good_Will_Slider.value, Total_Points, Time.deltaTime); // always lerping our goodwill slider value to the amount of points the player has in total

		Point_Text.text = "Goodwill: " + string.Format("{0:0}", Total_Points);

		if (Player_In_Bad_Driving_Zone == true) { // checking to see if the player is currently in a bad driving zone

			milliseconds -= Time.deltaTime*Decrease_Time * 1000; // subtracting time passed in milliseconds from our millisecons variable
			if (milliseconds <= 0) { // checking to see if milliseconds is less than or equal to 0
				Total_Points -= Point_Decrease; // subtracting point decrease as long as we are in an area
				milliseconds = 1000; // resseting our millisections to 10000

			}

		
		
		}
		
	}

	void OnTriggerEnter(Collider col){ // checking to see if an object is collided with 

		if (col.gameObject.tag == "Point") { // checking to see if the object collided with is tagged as point
			Destroy (col.gameObject); // destroying the gameobject that is collected
			Total_Points += Point_Increase; // adding our point increase to ourplayers total points
		

		}



		if (col.gameObject.tag == "Bad_Driving") { // checking to see if the object colided with is a out of bounds

			Player_In_Bad_Driving_Zone = true; // the player is currently in a bad driving zone

		}


	}

	void OnTriggerExit(Collider col){ // checking to see if a player leaves a trigger
		if (col.gameObject.tag == "Bad_Driving") { // checking to see if the object collided with is an out of bounds
			Player_In_Bad_Driving_Zone = false; // telling the game that the player is not in a bad driving zone

		}

	}

	void OnCollisionEnter(Collision col){ // checking to see if the player ahs collided witha  solid object

		if (col.gameObject.tag == "Enemy_Car") { // checking to see if the player has collided with an enemy car
			Total_Points -= Point_Increase*2; // subtracting points from our player


		}
	}

	void Color_Of_Slider(){ // creating a function to change the color of our slider based on how the player is doing
		Color Current_Color = Slider_Fill.GetComponent<Image>().color; // getting the current color of our background at this moment
		Color Good_Color = new Color(Player_Doing_Well.r,Player_Doing_Well.g,Player_Doing_Well.b); // creating a private color to change the background of our slider
		Color Neutral_Color = new Color(Player_Doing_Neutral.r,Player_Doing_Neutral.g,Player_Doing_Neutral.b); // creating a private color to change the background of our image
		Color Bad_Color = new Color (Player_Doing_Bad.r,Player_Doing_Bad.g,Player_Doing_Bad.b); // creatinga  a private color to change the background of our image

		if (Total_Points > ((Good_Will_Slider.maxValue + Good_Will_Slider.minValue) / 2) + Point_Increase) { // checking to see if the player is doing well
			
			Slider_Fill.color = Color.Lerp (Current_Color, Good_Color, Time.deltaTime); // lerping the color of our background  to change
			Slider_Loading.color = Color.Lerp(Current_Color,Good_Color,Time.deltaTime); // lerping hte color of our loading bar to change it
		}

		if(Total_Points <= ((Good_Will_Slider.maxValue + Good_Will_Slider.minValue)/2)+ Point_Increase && Total_Points >= ((Good_Will_Slider.maxValue +Good_Will_Slider.minValue)/2)-Point_Increase){

			Slider_Fill.color = Color.Lerp (Current_Color,Neutral_Color, Time.deltaTime); // lerping the color of our background  to change
			Slider_Loading.color = Color.Lerp(Current_Color,Neutral_Color,Time.deltaTime); // lerping hte color of our loading bar to change it
		}


		if(Total_Points < ((Good_Will_Slider.maxValue + Good_Will_Slider.minValue) / 2) - Point_Increase){

			Slider_Fill.color = Color.Lerp (Current_Color,Bad_Color, Time.deltaTime); // lerping the color of our background  to change
			Slider_Loading.color = Color.Lerp(Current_Color,Bad_Color,Time.deltaTime); // lerping hte color of our loading bar to change it
		}


	}
}
