/// <header>
/// Module:            Navigation
/// Date of creation: 13-04-17
/// Author:			  Rohan Aggarwal
/// Modification history:
/// 	13-04-17: Created module with initialization functions
/// 	14-04-17: Added functionality to rotate screen on touch input
/// 	15-04-17: Added functionality to move front and back.
/// 	16-04-17: Documented code.
/// Synopsis:
///		The module is responsible for navigating the user through the 3D space.
/// 	It supports touch swipe to rotate the view and also front and back buttons to
/// 	move the augmented user. It also sets the animation of the augmented user based on the current state.
/// Global variables:
/// public GameObject PLAYER;
/// public static bool PRESSED;
/// Functions:
/// 	void Start ()
/// 	void Update ()
/// 	void rotateObject()
/// 	void moveFront()
/// 	void moveBack()
/// 	public void OnPointerDown(PointerEventData eventData)
/// 	public void OnPointerUp(PointerEventData eventData)
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


public class Navigation : MonoBehaviour,IPointerDownHandler,IPointerUpHandler {

	//Global variables from the unity studio
	public GameObject PLAYER;//Game object of the augmented user.
	public static bool PRESSED;//A state to check whether a navigation button(UP/DOWN) was pressed.

	//private variables used in the class
	private Animator ANim;// animator component of the augmented user.
	private static Vector2 FIngerStart, FIngerEnd;// variables used in touch input to detect the length of screen swipe.
	private string BUttonPressed;//check which one of UP/DOWN button was pressed.


	/// <summary>
	/// Start this instance.
	/// Initialize ButtonPressed to "false"	 indicating no button is pressed.
	/// Fetch the animator component of the augmented user.
	/// </summary>
	void Start () {
			BUttonPressed = "false";
			PRESSED = false; // either of the button not pressed.
			ANim = PLAYER.GetComponent<Animator> ();
	}

	/// <summary>
	/// Update this instance,once every frame.
	/// Checks for button press and based on which button is pressed, calls the appropriate function.
	/// Monitors swipe input as well.
	/// </summary>
	void Update () {

			if (PRESSED) { // a button was pressed
				if(BUttonPressed == "upButton"){ // if it is UP button
					moveFront (); // move front on screen
				}
				if(BUttonPressed == "downButton") { // if it is DOWN button
					moveBack (); // move back on screen
				}
				ANim.SetBool ("isrunning", true); // the person is moving

			}
			rotateObject (); // check for swipe input.

	}
	/// <summary>
	/// Based on whether touch input was there or not, rotate the view of the augmented user
	/// Takes care of both swipe left and swipe right.
	/// </summary>

	void rotateObject()
	{
		foreach (Touch touch in Input.touches) { // check for touch input.
				if (touch.phase == TouchPhase.Began) { // just beginining to swipe
					// set the starting and ending position of touch same.
					FIngerStart = touch.position;
					FIngerEnd = touch.position;
				}
			if (touch.phase == TouchPhase.Moved) { // swiping in transition
				FIngerEnd = touch.position;//ending position is current touch position.
				if (FIngerEnd.x - FIngerStart.x < -10) { // sufficient left swipe
					// rotate the player object
					float rotat = -150.0f;
					rotat *= Time.deltaTime;
					PLAYER.transform.Rotate (0, rotat, 0);
				}
				if (FIngerEnd.x - FIngerStart.x > 10) { // sufficient right swipe
					// rotate the player object
					float rotat = 150.0f;
					rotat *= Time.deltaTime;
					PLAYER.transform.Rotate (0, rotat, 0);
				}
				FIngerStart = touch.position; // update the start position
			}

			if (touch.phase == TouchPhase.Ended) { // swipe ended
				//reset finger start and end.
				FIngerStart = Vector2.zero;
				FIngerEnd = Vector2.zero;
			}

		}

	}

	/// <summary>
	/// Moves the augmented user front. Also confirms with the Boundaries module that 
	/// the move is valid.
	/// </summary>
	void moveFront(){ 
		float translation = 3.0f;//constant transalation for moving front.
		translation *= Time.deltaTime;

		PLAYER.transform.Translate (0, 0, translation);

		// in case of invalid move, retranslate the player back to his original position.
		if(Boundaries.check_Collision(PLAYER) == true) PLAYER.transform.Translate (0, 0, -translation);

	}

	/// <summary>
	/// Moves the augmented user back. Also confirms with the Boundaries module that 
	/// the move is valid.
	/// </summary>
	void moveBack(){ 
		float translation = -3.0f;//note the negative sign.
		translation *= Time.deltaTime;

		PLAYER.transform.Translate (0, 0, translation);

		if(Boundaries.check_Collision(PLAYER) == true) PLAYER.transform.Translate (0, 0, -translation);

	}
	/// <summary>
	/// The below two are inbuilt driver function to check UP/DOWN button press down and release.
	/// It is used to facilitate continous touch on UP/DOWN button to move the user  continously.
	/// </summary>
	/// <param name="eventData">Event data.</param>


	public void OnPointerDown(PointerEventData eventData)
	{
		PRESSED = true; // some button is pressed

		//get the name of the button pressed(UP/DOWN)
		BUttonPressed = EventSystem.current.currentSelectedGameObject.name;

	}

	public void OnPointerUp(PointerEventData eventData)
	{
		//button pressed released.
		PRESSED = false;
		BUttonPressed = "false";
	}

	/************* END OF CLASS ***********/
}
