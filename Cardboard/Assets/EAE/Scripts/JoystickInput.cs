using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterValues
{
	public float RotationXVelocity { set; get; } 
	public float MovementForward { set; get; }
	public float MovementMechanism { set; get; }
};



public class JoystickInput : MonoBehaviour {
	
	public CharacterValues CharacterValues { private set; get; }

	protected VRHelpfulFunctions _vrHelpfulFunctions { private set; get; }

	protected void InitVRHelpfulFunctions()
	{
		_vrHelpfulFunctions = gameObject.AddComponent<VRHelpfulFunctions> ();
	}

	public void Init()
	{
		CharacterValues = new CharacterValues ();
		CleanData ();

		InitVRHelpfulFunctions ();
	}

	protected void CleanData()
	{
		CharacterValues.MovementForward = 0.0f;
		CharacterValues.RotationXVelocity = 0.0f;
		CharacterValues.MovementMechanism = 0.0f;
	}
}
