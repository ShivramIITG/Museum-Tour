/// <header>
/// Module:            Button_Setup
/// Date of creation: 15-04-17
/// Author:			  Shivram N
/// Modification history:
/// 	15-04-17: Created module and functionality to check for button press and change animation.
/// 	16-04-17: Documented code.
/// Synopsis:
/// The module checks if some button was pressed using the navigation module and based on that, sets 
/// the animation in the INIT_and_3D module.
/// Global variables:
/// 	NONE
/// Functions:
///		void Update ()
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


public class Button_Setup : MonoBehaviour {


	/// <summary>
	/// Update this instance,once a frame.
	/// </summary>
	void Update () {
		if (Navigation.PRESSED == false) {
			Init_and_3D.ANIM.SetBool ("isrunning", false); // player stopped in case no button is pressed.
		}
	}

	/************* END OF CLASS ***********/ 
}
