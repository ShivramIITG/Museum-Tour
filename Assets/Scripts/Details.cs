/// <header>
/// Module:            Details
/// Date of creation: 14-04-17
/// Author:			  Tamil Selvan
/// Modification history:
/// 	13-04-17: Created module and functionality to return details of the selected object.
/// 	16-04-17: Documented code.
/// Synopsis:
/// The module takes a string(name of object) as an input and fetches its details from the 
/// database module and returns it.
/// Global variables:
/// 	NONE
/// Functions:
///		public static string returnDetails(string objname)
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

public class Details : MonoBehaviour {

	/// <summary>
	/// Returns the details of the given object.
	/// </summary>
	/// <returns>The details of the object.</returns>
	/// <param name="objname">Objname.</param>
	public static string returnDetails(string objname){
		return Database.getDetails (objname);
	}


	/************* END OF CLASS ***********/ 
}
