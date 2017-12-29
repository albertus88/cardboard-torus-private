using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHelpfulFunctions : MonoBehaviour 
{
	public void Recenter() {
		#if !UNITY_EDITOR
		GvrCardboardHelpers.Recenter();
		#else
		if (GvrEditorEmulator.Instance != null) 
		{
			GvrEditorEmulator.Instance.Recenter();
		}
		#endif  // !UNITY_EDITOR
	}

}
