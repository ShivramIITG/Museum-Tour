/// <header>
/// Module:            Main Menu
/// Date of creation: 14-04-17
/// Author:			  Rohan Aggarwal
/// Modification history:
/// 	14-04-17: Created module and added drop down for museum/section selection.
/// 	16-04-17: Documented code.
/// Synopsis:
/// The module is responsible for the main menu display and musuem, section selection.
/// Global variables:
/// 	public Dropdown DROP;
/// Functions:
///		void Start ()
/// 	public void DropdownIndexChanged(int index)
/// 	void PopulateList()
/// </header>


// imports required from the UnityEngine module
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// imports required from the System module
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;//for debugging
using System.Text;//for debugging

public class Main_Menu : MonoBehaviour {

	public Dropdown drop;
	// Use this for initialization
	/// <summary>
	/// Start this instance and populates the DROP list.
	/// Initializes the database module.
	/// </summary>
	void Start () {
		Database.Start ();
		PopulateList ();
	}

	/// <summary>
	/// Based on selected section, this listener changes the unity-scene to the reqd section.
	/// </summary>
	/// <param name="index">Index.</param>
	public void Dropdown_IndexChanged(int Index)
	{
		//load the reqd section based on users input.
		if (Index == 0) {
			SceneManager.LoadScene (0);
		}
		if (Index == 1) {
			SceneManager.LoadScene (1);
		}
		if (Index == 2) {
			SceneManager.LoadScene (2);
		}
		if (Index == 3) {
			SceneManager.LoadScene (3);
		}
	}

	/// <summary>
	/// Populates the DROP list.
	/// </summary>
	void PopulateList()
	{
		List <string> names = Database.getSectionList ();
		drop.AddOptions (names);
	}
}
