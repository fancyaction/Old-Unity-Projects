using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Input.GetMouseButtonDown(0)) {
			DestroyObject (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
