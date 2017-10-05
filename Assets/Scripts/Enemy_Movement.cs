using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour {

	public float Enemy_Speed; // creating a speed variable to adjust our enemy speed
	public GameObject Enemy_Spawn_Position; // creating a public gameobject to set our enemy spawn position
	public GameObject Enemy_Trigger; // creating a piblic gameobejct for our enemy trigger

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += Vector3.forward * Enemy_Speed * Time.deltaTime; // moving our enemy forward by time and our enemy speed
		
	}

	void OnTriggerEnter(Collider col){ // checking to see if the enemy has entered any trigger at all

		if (col.gameObject == Enemy_Trigger) { // checking to see if the trigger the enemy has entered is supposed to have destroyed it
			
			Instantiate(gameObject,Enemy_Spawn_Position.transform.position,Quaternion.identity); // create a copy of this gameobject and spawn it
			Destroy(gameObject); // destroying the original gameobject that passed through the trigger
		}

	}
}
