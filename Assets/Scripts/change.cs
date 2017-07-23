/// <header>
/// Module:            change
/// Date of creation: 13-04-17
/// Author:			  Shivram N
/// Modification history:
/// 	13-04-17: Created module and functionality to change scene
/// 	16-04-17: Documented code.
/// Synopsis:
/// The module is responsible for changing scenes.
/// Global variables:
/// 	public int scene;
/// Functions:
///		void Start ()
/// 	public void changetoScene()
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class change : MonoBehaviour {

	//Global variables from the unity studio
	public int scene;//scene number of the selected scene

	/// <summary>
	///change to the appropriate scene.
	/// </summary>
	public void changetoScene()
	{
		SceneManager.LoadScene (scene);

	}

}
