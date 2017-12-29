using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawDummy : MonoBehaviour {

	void OnDrawGizmosSelected() {
		Gizmos.color = new Color(1, 0, 0, 0.5F);
		Gizmos.DrawCube(transform.position, new Vector3(0.1f, 0.1f, 0.1f));
	}
}
