using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will move the camera and make it look at stuff

public class Camera_Control : MonoBehaviour {

	public Transform lookAtTarget; // what is the camera supposed to look at
	public Transform moveToTarget; // where should the camera go

	public float Move_Speed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (lookAtTarget != null) {
			transform.LookAt (lookAtTarget.position);

		}

		if (moveToTarget != null) {

			Vector3 moveDirection = moveToTarget.position - transform.position;



			if(moveDirection.magnitude > 1f){

				moveDirection = moveDirection.normalized;
			}

			transform.position += moveDirection * Time.deltaTime * Move_Speed;
		}
		
	}
}
