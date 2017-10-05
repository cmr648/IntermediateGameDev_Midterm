using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webcam_Render : MonoBehaviour {

	// Use this for initialization
	void Start () {
		WebCamTexture My_Webcam_Texture = new WebCamTexture (); // creating a new webcam texture called my webcam texture
		Renderer My_Renderer = GetComponent<Renderer> (); // getting the renderer of our current game object
		My_Renderer.material.mainTexture = My_Webcam_Texture; // taking the main material of our gameobject and applying our webcam texture to it

		My_Webcam_Texture.Play (); // playing our webcam texture
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
