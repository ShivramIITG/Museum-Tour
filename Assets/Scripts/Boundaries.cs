/// <header>
/// Module:            Boundaries
/// Date of creation: 13-04-17
/// Author:			  Shivram N
/// Modification history:
/// 	13-04-17: Created module and functionality to check collision with the boundaries of the museum.
/// 	16-04-17: Documented code.
/// Synopsis:
/// The module takes the user object as the input and checks if there is a collision with any of the 
/// walls of the museum.
/// Global variables:
/// 	NONE
/// Functions:
///		public static bool check_Collision(GameObject player)
/// 	public static bool testModule(GameObject player)
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

public class Boundaries : MonoBehaviour {

	/// <summary>
	/// Checks for collison between player and any of the walls.
	/// </summary>
	/// <returns><c>true</c>, if collision was there, <c>false</c> otherwise.</returns>
	/// <param name="player">Player.</param>

	public static bool check_Collision(GameObject player){
		//fetch all the game objects tagged as walls
		GameObject[] walls = GameObject.FindGameObjectsWithTag ("Walls");

		foreach (GameObject wall in walls) {
			//The below line checks for colision using unity Engine module.
			while (wall.transform.GetComponent<Renderer> ().bounds.Contains (player.transform.position))
			{
				return true;
			}
		}

		return false; // Collision with No wall.
	}

	/// <summary>
	/// Used in black box unit testing of the module.Created by the module author to facilitate black box testing.
	/// </summary>
	/// <param name="player">Player object to check for collision</param>
	public static bool testModule(GameObject player){
		return check_Collision (player); // check if the test object collides with any of the wall.
	}


	/************* END OF CLASS ***********/ 
}
