using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInputMobile : JoystickInput {

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CleanData ();

		if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0.5f) 
        {
			CharacterValues.RotationXVelocity = Input.GetAxis ("Vertical");
			Debug.Log ("El value vertical es " + Input.GetAxis ("Vertical"));
		}

        if (Mathf.Abs(Input.GetAxis ("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxis("Vertical")) > 0.5f) 
		{
			CharacterValues.MovementForward = -Input.GetAxis("Horizontal");
			Debug.Log ("El value horizontal  es " + Input.GetAxis ("Horizontal"));
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button3)) 
		{
			_vrHelpfulFunctions.Recenter ();
		}

		if(Input.GetKeyDown(KeyCode.Escape)) 
		{
			Application.Quit();
		}

		foreach(KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(kcode))
				Debug.Log("KeyCode down: " + kcode);
		}	
	}
}
