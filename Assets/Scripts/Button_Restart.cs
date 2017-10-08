using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Restart : MonoBehaviour {

	public string Next_Level;
	public KeyCode Button_Restart_Key;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (Button_Restart_Key)) {
			SceneManager.LoadScene (Next_Level);

		}

	}
}
