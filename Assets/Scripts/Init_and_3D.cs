/// <header>
/// Module:            Init_and_3D
/// Date of creation: 12-04-17
/// Author:			  Shivram N
/// Modification history:
/// 	12-04-17: Created module with initialization functions
/// 	13-04-17: Added details button show/hide based on artefact(s) distance functionality
/// 	14-04-17: Added functionality to show popup and close them
/// 	16-04-17: Documented code.
/// Synopsis:
/// 	The module is responsible for initializing database and 3D visualization. The module
/// 	computes the closest artefact nearby and based on its distance, shows/hides the 
/// 	VIEW button. It also opens the popup fetching details of the nearby artefact from 
/// 	the details module and then displays them to the user on screen. Close functionality
/// 	is also added to the popup box.
/// Global variables:
/// 	public static Animator ANIM;
///     public Button DETAILS_BUTTON;
/// Functions:
/// 	void Start ()
/// 	void Update ()
/// 	void showViewButton()
/// 	GameObject NearbyartefactIdentifier()
/// 	void viewButtonListener()
/// 	GameObject checkInteraction()
/// 	void OnGUI()
/// 	void CallDetails(int windowid)
/// 	void popupDisplay(string objname,string objdetails)
/// </header>


// imports required from the UnityEngine module
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// imports required from the System module
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;//for debugging
using System.Text;//for debugging


public class Init_and_3D : MonoBehaviour {

	//Global variables from the unity studio
	public static Animator ANIM; // animation for the player object
	public Button VIEWBUTTON;

	//private variables used in the class
	private GameObject[] ARtefacts; // list of artefacts present in the section
	private bool SHowPopUp;// boolean to set the visibility of GUI pop up


	/// <summary>
	/// Start this instance.
	/// Initialize the database module.
	/// Fetch the animator component and the list of artefacts.
	/// Initialize the view button.
	/// </summary>
	void Start () {
		Database.Start ();

		ANIM = GetComponent<Animator> ();
		ARtefacts = GameObject.FindGameObjectsWithTag ("Pickup");

		SHowPopUp = false; // GUI pop up is initially hidden.

		Button view = VIEWBUTTON.GetComponent<Button> (); 
		view.onClick.AddListener (viewButtonListener); // add a onclick listener to the view button.

	}

	/// <summary>
	/// Update this instance,once a frame.
	/// </summary>
	void Update () {
		showViewButton (); // continously check if view button needs to be shown in every frame.
	}


	/// <summary>
	/// Shows the view button in case an artefact is nearby.
	/// </summary>
	void showViewButton(){
		foreach (GameObject artefact in ARtefacts) {
			//compute the distance between current artefact and the player
			//transform gives postion of player and artefact.transform gives that of artefact
			float Distance = Vector3.Distance (transform.position, artefact.transform.position);

			if (Distance <= 8.0f) { // in case the current artefact is close enough
				VIEWBUTTON.gameObject.SetActive(true);// make the view button visible
				return;
			} 
		}
		VIEWBUTTON.gameObject.SetActive (false); // no artefact is close enough, view button invisible.
		return;
	}

	/// <summary>
	/// Identify and return the nearby artefact based on the players position.
	/// </summary>
	/// <returns>The artefact identifier.</returns>
	GameObject NearbyartefactIdentifier(){
		foreach (GameObject artefact in ARtefacts) {
			//compute the distance between current artefact and the player
			//transform gives postion of player and artefact.transform gives that of artefact
			float distance = Vector3.Distance (transform.position, artefact.transform.position);

			if (distance <= 8.0f) { // in case the current artefact is close enough
				VIEWBUTTON.gameObject.SetActive(true); // make the view button visible
				return artefact; // return the nearby artefact.
			} 
		}
		VIEWBUTTON.gameObject.SetActive (false); // no artefact is close enough, view button invisible.
		return null;//null object returned indicating that no object is present nearby.
	}

	/// <summary>
	/// executed when the VIEW buton is pressed.
	/// </summary>
	void viewButtonListener(){
		SHowPopUp = true; // in case the view button is pressed.
	}

	/// <summary>
	/// Finds out which artefact the user interacted with. 
	/// </summary>
	GameObject checkInteraction()
	{
		return NearbyartefactIdentifier ();
	}

	/// <summary>
	/// Acts as a driver to create the GUI popup.
	/// </summary>

	void OnGUI()
	{
		if (SHowPopUp) { // meaning view button was pressed.
			GameObject artefact = checkInteraction (); // Find the artefact the user interacted with.
			Rect windowRect = new Rect(10, 10, 3000, 3000);// create a GUI rectangle
			if(artefact) // Checking for error, artefact is not NULL
				GUI.Window (0,windowRect, CallDetails, artefact.name); // create a GUI window

		}
	}

	/// <summary>
	/// Fetches details of the nearby artefact from the Details module and 
	/// then calls a function to display it on the popup.
	/// </summary>
	/// <param name="windowid">Window ID.</param>
	void CallDetails(int windowid){
		string objname = NearbyartefactIdentifier ().name; // get the name of nearby artefact.
		string objdetails = Details.returnDetails (objname); // query the details module with the object name
		// and fetch the details

		popupDisplay (objname, objdetails); // display the details

	}


	/// <summary>
	/// Displays the details of the artefact on the GUI window.
	/// </summary>
	/// <param name="objname">Object name.</param>
	/// <param name="objdetails">Object details.</param>
	void popupDisplay(string objname,string objdetails){
		GUIStyle style = new GUIStyle(); // GUI style for styling the box.
		style.fontSize = 50;

		GUI.Label(new Rect(65,110,600,600),objdetails + " " + objname,style);//display the details along with style.


		if (GUI.Button (new Rect (300, 1000, 300, 90), "OK")) {//OK button pressed
			SHowPopUp = false;//close the pop up.
		}
	}

	/************* END OF CLASS ***********/

}
