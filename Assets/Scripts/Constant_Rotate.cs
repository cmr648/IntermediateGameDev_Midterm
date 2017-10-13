using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant_Rotate : MonoBehaviour {

	public float Rotate_Speed; // creating a public float for the speed we want to rotate

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (Vector3.forward * Rotate_Speed * Time.deltaTime); // setting our transform to rotate at a constant speed in the forward direction
		
	}
}
