using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour {

	[SerializeField]
	float Current_Selection; // creating a float for the current selection fo our menu

	GameObject[] Menu_Selector_List; // creating a list for every menu selctor we create

	public GameObject Menu_Selector_1; // creating a public gameobject for our first menu selector
	public GameObject Menu_Selector_2; // creating a public gameobject for our second menu selector
	public GameObject Menu_Selector_3; // creating a public gameobject for our third menu selector


	public GameObject Instructions_Panel; // creating a public gameobject for our instructions Panel
	public GameObject Credits_Panel; // creating a public gameobject for our credits panel

	public GameObject Play_Text; // creating a public gameobject for our play text
	public GameObject Instructions_Text; // creating a public gameobject for our instructions text
	public GameObject Credits_Text;  // creating a public gameobject for our credits text

	public bool Can_Use_Arrow_Keys; // creating a bool to decide when the player can use arrow keys
	public bool Can_Show_Selectors; // creating a bool to decide when we can show selectors

	Fader_Script Fade_Out_Now; // creating a referecne to our fader script


	// Use this for initialization
	void Start () {
		

		Menu_Selector_List = GameObject.FindGameObjectsWithTag ("Menu_Selector"); // adding all fo our menu selctors to our menu selector list
		Current_Selection = 1; // setting our current selction to be equal to 1 at the begginign of our game
		Instructions_Panel.SetActive(false); // turning our instructions panel off
		Credits_Panel.SetActive(false); // turning our credits panel off
		Can_Use_Arrow_Keys = true; // setting this to allow our player to use arrow keys
		Can_Show_Selectors = true; // setting this to allow to show selctors
		Fade_Out_Now = GetComponent<Fader_Script>(); // setting our fade out now script reference
	}
	
	// Update is called once per frame
	void Update () {

		if (Can_Use_Arrow_Keys == true) { // checking to see if the player can use arrow keys
			Arrow_Key_Selection (); // implementing our arrow key selection function
		}

		if (Can_Show_Selectors == true) {
			Show_Selectors(); // implementing our show selectors function
		}

		Enter_Selection(); // implementing our enter selection function
	}


	void Arrow_Key_Selection(){

		if (Input.GetKeyDown(KeyCode.DownArrow)) { //  checking to see if the down arrow key has been pressed

			Current_Selection++; // add 1 to our current selection

		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) { // checking to see if the up arrow key has been pressed

			Current_Selection--; //subtract 1 from our current selction
		}

		if (Current_Selection > Menu_Selector_List.Length) { // checking to see if the current selection variable is greater than the amount of selectors

			Current_Selection = 1; // ressetting current selection back to 1
		}

		if (Current_Selection < 1) { // checking to see if our current selection is less than 1 

			Current_Selection = Menu_Selector_List.Length; // setting it to the maximum amount of selectors there are
		}



	}

	void Show_Selectors(){
		if (Current_Selection == 1) { // checking to see what the current selction is and setting what is visible accordingly
			Menu_Selector_1.SetActive (true);
			Menu_Selector_2.SetActive (false);
			Menu_Selector_3.SetActive (false);

		}

		if (Current_Selection == 2) { // checking to see what the current selction is and setting what is visible accordingly
			Menu_Selector_1.SetActive (false);
			Menu_Selector_2.SetActive (true);
			Menu_Selector_3.SetActive (false);

		}

		if (Current_Selection == 3) { // checking to see what the current selction is and setting what is visible accordingly
			Menu_Selector_1.SetActive (false);
			Menu_Selector_2.SetActive (false);
			Menu_Selector_3.SetActive (true);

		}



	}

	void Enter_Selection(){ // creating a function to decide what will happen when the player presses the enter key
		if (Input.GetKeyDown (KeyCode.Return) && Current_Selection == 1) { // checking to see if we are on selection 1
		//	SceneManager.LoadScene ("Control_Test"); // loading the main game scene
			Fade_Out_Now.Can_Fade_Out = true; // setting our fader to fade out

		}

		if (Input.GetKeyDown (KeyCode.Return) && Current_Selection == 2) { // checking to see if we are on selection 2
			Can_Use_Arrow_Keys = false;
			Can_Show_Selectors = false;
			Menu_Selector_1.SetActive (false);
			Menu_Selector_2.SetActive (false);
			Menu_Selector_3.SetActive (false);
			Instructions_Panel.SetActive (true);
			Credits_Panel.SetActive (false);
			Play_Text.SetActive (false);
			Instructions_Text.SetActive (false);
			Credits_Text.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Return) && Current_Selection == 3) { // checking to see if we are on selection 2
			Can_Use_Arrow_Keys = false;
			Can_Show_Selectors = false;
			Menu_Selector_1.SetActive (false);
			Menu_Selector_2.SetActive (false);
			Menu_Selector_3.SetActive (false);
			Instructions_Panel.SetActive (false);
			Credits_Panel.SetActive (true);
			Play_Text.SetActive (false);
			Instructions_Text.SetActive (false);
			Credits_Text.SetActive (false);
		}


		if (Input.GetKey (KeyCode.Escape)) {
			Can_Use_Arrow_Keys = true;
			Can_Show_Selectors = true;
			Instructions_Panel.SetActive (false);
			Credits_Panel.SetActive (false);
			Play_Text.SetActive (true);
			Instructions_Text.SetActive (true);
			Credits_Text.SetActive (true);
		}



	}
}
