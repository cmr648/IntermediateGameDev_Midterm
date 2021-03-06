﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Raycast_Movement : MonoBehaviour {

	public float Max_Ray_Distance; // creatinga  public float to edit our max ray distance
	public float Enemy_Car_Speed; // creating a float for our enemy car speed

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Ray Enemy_Raycast = new Ray (transform.position, transform.forward); // creating a new ray for our car that will go out of the front of our transform
		RaycastHit Car_Turn_Hit; // creating a raycast hit in order to check the tag of something that our enemy has hit

		Debug.DrawRay (Enemy_Raycast.origin, Enemy_Raycast.direction * Max_Ray_Distance, Color.magenta); // drawing our ray in debug to see how far it goes

		if(Physics.Raycast(Enemy_Raycast,out Car_Turn_Hit,Max_Ray_Distance)){ // checking to see if our raycast has hit

			if (Car_Turn_Hit.transform.gameObject.tag == "Invisible_Wall" || Car_Turn_Hit.transform.gameObject.tag == "Enemy_Car" || Car_Turn_Hit.transform.gameObject.tag == "Point") { // checking to see if the gameobject that the car is tagged with is a bad driving zone


			if (Random.Range (0, 100f) > 50f) { // checking to see if 50% of the time  a random number is greater than 50
					transform.Rotate (0, 90f, 0); // rotating the transoform of our enemy car
			} else {
				transform.Rotate (0, -90f, 0); // rotation our transform of our enemy car
				} 

			}

		} else{
			transform.Translate(0f,0f,Enemy_Car_Speed*Time.deltaTime); // moving our enemy car at all times unless it needs to
		}

		
	}
}
