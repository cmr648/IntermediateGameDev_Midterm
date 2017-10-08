using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap_Parent : MonoBehaviour {

	public GameObject Player_Transform; // creating a public transform reference to our player
	Driving_Controls Driving; // creating a reference for our driving controls
	Camera Minimap_Camera; // creating a reference for our minimap camera
	Rigidbody Player_RigidBody; // creating a reference for our player rigidbody

	public float Max_Camera_Zoom; // setting our max camera zoom variable
	public float Time_To_Zoom; // setting our time for the camera to zoom
	public float MiniMap_Min_Size; // setting our minimum size for our camera
	public float Minimap_Max_Size; // setting our maximum size for our camera

	// Use this for initialization
	void Start () {
		Driving = Player_Transform.GetComponent<Driving_Controls> (); // getting a component for our players driving controls
		Minimap_Camera = GetComponent<Camera>(); // getting the current camera script on our minimap
		Player_RigidBody = Player_Transform.GetComponent<Rigidbody>(); // assigning our player rirgidbody
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 Minimap_Position; // creatinga  vector 3 for our players minimap position
		Minimap_Position = new Vector3 (Player_Transform.transform.position.x,transform.position.y,Player_Transform.transform.position.z); // setting our minimap position to follow the player
		transform.position = Minimap_Position; // setting our minimap position constantly
		transform.rotation = Quaternion.Euler(90f,Player_Transform.transform.eulerAngles.y,0f); // setting our minimap cameras rotation to be equal to the player


		MiniMap_Zoom();
	}

	void  MiniMap_Zoom () { // creating a new function for our minimap zoom


		Minimap_Camera.orthographicSize = Mathf.Lerp (Minimap_Camera.orthographicSize, Minimap_Camera.orthographicSize * (Mathf.Abs(Player_RigidBody.velocity.z) * Max_Camera_Zoom) + MiniMap_Min_Size, Time.deltaTime * Time_To_Zoom); // lerping the camera to the max possible size we set
		if (Minimap_Camera.orthographicSize >= Minimap_Max_Size) { // if the minimap size goes over the minimap max size

			Minimap_Camera.orthographicSize = Minimap_Max_Size; // setting the threshold of the minimaps max size
		}

	}

}
