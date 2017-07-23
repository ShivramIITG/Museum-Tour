/// <header>
/// Module:            Database
/// Date of creation: 13-04-17
/// Author:			  Tamil Selvan
/// Modification history:
/// 	13-04-17: Created module with initialization functions
/// 	14-04-17: Created the functionalities for fetching details of artefacts and section list of museum.
/// 	16-04-17: Documented code.
/// Synopsis:
/// 	The module is responsible for establishing communication with the database(Files in the case of this project)
/// 	and to return the required details to some other module.
/// Global variables:
/// 	NONE
/// Functions:
/// 	public static void Start ()
/// 	public static List<string> testModule(int functionid,string input)
/// 	public static string getDetails(string objname)
/// 	public static List<string> getSectionList()
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

public class Database : MonoBehaviour {

	//private variables used in the class
	public static string[] DetailsOfArtefacts;//list of artefact details fetched from the database.
	public static List<string> SectionList;//list of sections in the museum.

	/// <summary>
	/// Start this instance.
	/// Fetch the section list and the details of artefacts from the database.
	/// </summary>

	public static void Start () {
		TextAsset det = Resources.Load<TextAsset> ("Details"); // fetch from Database(File:Details.txt)
		DetailsOfArtefacts = det.text.Split ('\n');

		TextAsset sec = Resources.Load<TextAsset> ("section"); // fetch from Database(File:section.txt)
		SectionList = new List<string>(sec.text.Split ('\n'));

	}

	/// <summary>
	/// Used in black box unit testing of the module.Created by the module author to facilitate black box testing.
	/// </summary>
	/// <param name="functionid">Functionid. -- 0 for getDetails, 1 for getSectionList</param>
	/// <param name="input">Input.</param>
	public static List<string> testModule(int functionid,string input){
		if (functionid == 0) { // create a list of single string and return the artefact detail
			List<String> detailsreturn = new List<string> {getDetails (input)};
			return detailsreturn;
		} else { // return the section list
			return getSectionList ();
		}
	}

	/// <summary>
	/// returns the details of the given artefact name.
	/// </summary>
	/// <param name="objName">Object name.</param>

	public static string getDetails(string objName){

		int i = 0;//counter to move through the list of <artefact,details-of-artefact>
		while (i < DetailsOfArtefacts.Length) {
			if (objName == DetailsOfArtefacts[i].Trim() ) // artefact found.
				break;
			i++;
		}
		if (i < DetailsOfArtefacts.Length) // in case object found.
			return DetailsOfArtefacts [i + 1]; //return the details of object found.
		else
			return "NOT FOUND"; //  object not found. return error message.
	}

	/// <summary>
	/// Return the list of sections in the museum.
	/// </summary>
	/// <returns>The section list.</returns>
	public static List<string> getSectionList(){
		return SectionList;
	}



	/************* END OF CLASS ***********/ 
}
