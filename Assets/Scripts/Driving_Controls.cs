using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving_Controls : MonoBehaviour {

	Vector3 Input_Vector; // creating a vector 3 that will function as all input commands
	Rigidbody Player_Rigid_Body; // creating an rigidbody variable for our player
	public float Player_Speed; // creating a public float to eddit the force our player moves at
	public float Turn_Speed; // creating a variable for the speed of our turning
	public float Player_Max_Speed; // creating a variable for the max speed we will allow the player to go

	[SerializeField] //creates a seperate unity field similar to when setting things to public
	float CameraDistance; // creating a unity editor field to measure the distance between our player in the camera


	public GameObject Cam;

	// Use this for initialization
	void Start () {
		Player_Rigid_Body = GetComponent<Rigidbody> (); // getting our players rigidbody and putting it in a variable
	}
	
	// Update is called once per frame
	void Update () {


		float Input_Forward = Input.GetAxis ("Vertical"); // getting our vertical axis to move our player forwards
		float Turning_Amount = Input.GetAxis ("Horizontal"); //getting our horizontal axis to rotate our player object

		if(Player_Rigid_Body.velocity.magnitude < Player_Max_Speed){ // checking to see if our player velocity is goign to be less than the max speed we set
		Player_Rigid_Body.AddForce (transform.forward * Player_Speed * Input_Forward); // adding force to our rigidbody in order to make our driving controls
		}

		gameObject.transform.Rotate(0f,Turning_Amount*Turn_Speed*Time.deltaTime,0f); // rotating our plyer game object based on the horizontal axis

		CameraDistance = (Vector3.Distance (transform.position, Cam.transform.position)); // setting our camera distance serialized field to display the distance of the camera to our player

	}

	void FixedUpdate(){ // a void that will function every frame rather than every rendered frame
		


	}
}
