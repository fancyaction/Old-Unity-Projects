using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	static bool playOnce = false;

	// Use this for initialization
	void Start () {
		if(!playOnce) {
			audio.Play ();
		}
		playOnce = true;
	}

	void Awake() {
		GameObject.DontDestroyOnLoad(this.gameObject);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
