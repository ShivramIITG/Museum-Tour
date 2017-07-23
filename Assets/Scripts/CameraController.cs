/// <header>
/// Module:            CameraController
/// Date of creation: 13-04-17
/// Author:			  Shivram N
/// Modification history:
/// 	13-04-17: Created module and functionality to control camera movement
/// 	16-04-17: Documented code.
/// Synopsis:
/// The module is responsible for camera moving right behind the player, it takes care of camera rotation as well.
/// Global variables:
/// 	public GameObject player;
/// Functions:
///		void Start ()
/// 	void LateUpdate ()
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


public class CameraController : MonoBehaviour {

	//Global variables from the unity studio
	public GameObject player;

	//private variables used in the class
	private float offset;
	private Vector3 scale;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		offset = Vector3.Distance(transform.position , player.transform.position); // maintain this distance b/w camera and player
		scale = new Vector3 (0.0f, 3.0f, 0.0f);  // scaling the distance
	}

	/// <summary>
	/// Update this instance,once at end of frame.Compute the camera position and orientation and set the same.
	/// Makes sure that camera is behind user.
	/// </summary>
	void LateUpdate () {

		//compute camera orientation.
		float deg = player.transform.rotation.eulerAngles.y;

		double sinDeg = Math.Sin ((Math.PI / 180) * deg);
		double cosDeg = Math.Cos ((Math.PI / 180) * deg);

		float xvar = (float)sinDeg;
		float zvar = (float)cosDeg;

		Vector3 dir = new Vector3 (xvar,0.0f,zvar);

		//set camera position and orientation
		transform.position = player.transform.position - offset*dir + scale;

		transform.rotation = player.transform.rotation;
	}
}
