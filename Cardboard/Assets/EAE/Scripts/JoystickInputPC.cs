using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInputPC : JoystickInput {

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
			CharacterValues.MovementForward = Input.GetAxis ("Vertical");
		}

        if (Mathf.Abs(Input.GetAxis ("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxis("Vertical")) > 0.5f) 
		{
			CharacterValues.RotationXVelocity = Input.GetAxis("Horizontal");
		}

		if (Input.GetKeyDown (KeyCode.J)) 
		{
			_vrHelpfulFunctions.Recenter ();
		}

		if (Input.GetKey (KeyCode.R)) 
		{
			CharacterValues.MovementMechanism = 1.0f;
		} 
		else if (Input.GetKey (KeyCode.F)) 
		{
			CharacterValues.MovementMechanism = -1.0f;
		}


		foreach(KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(kcode))
				Debug.Log("KeyCode down: " + kcode);
		}	
	}
}
