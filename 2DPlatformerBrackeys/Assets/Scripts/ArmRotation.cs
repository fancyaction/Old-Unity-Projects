﻿using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

	public int rotOffset = 90;

	// Update is called once per frame
	void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize (); 

		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg; //finding angle in degrees
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotOffset);
	}
}
