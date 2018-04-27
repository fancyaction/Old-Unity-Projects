using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public float flapSpeed = 100f;
	float forwardSpeed = 1f;

	bool didFlap = false;
	//bool isRestarting = false;

	public bool godMode = false;
	Animator animator;

	public bool dead = false;
	float deathCooldown;

	float coinCooldown = 1f;

	bool slowTime = false;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator>();
	}

	//Graphic & Input updates
	void Update() {
		if (dead) {
			deathCooldown -= Time.deltaTime;

			if(deathCooldown <= 0) {
				if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
					Application.LoadLevel("Main");
				}
			}
		}

		else {
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
				didFlap = true;
			}
		}

		//if(dead == true && Input.GetMouseButtonDown(0)) {
			//if (isRestarting == false) {
				//yield WaitForSeconds(3);
				//RestartLevel();
				//Debug.Log ("isrestarting");
		//	}
		//}
	}
	
	// Physics engine updates
	void FixedUpdate () {

		if(dead)
			return;




		rigidbody2D.AddForce(Vector2.right * forwardSpeed);

		if(didFlap) {
			rigidbody2D.AddForce(Vector2.up * flapSpeed);
			animator.SetTrigger("doFlap");
			transform.rotation = Quaternion.Euler (0,0,0);
			didFlap = false;
		}

		if(rigidbody2D.velocity.y > 0) {
			transform.rotation = Quaternion.Euler (0,0,0);
		}

		else {
			float angle = Mathf.Lerp (0,-90, (-rigidbody2D.velocity.y/3.5f));
			transform.rotation = Quaternion.Euler (0,0,angle);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(godMode)
			return;

		audio.Play ();
		animator.SetTrigger("Death");
		dead = true;
		deathCooldown = 1f;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Coin") {
			GetComponent<TrailRenderer>().enabled = true;
			Time.timeScale = 0.8f;
			coinCooldown -= Time.deltaTime;

			if(coinCooldown <= 0) {
				Time.timeScale = 1f;
				GetComponent<TrailRenderer>().enabled = false;
			}
		}
		//GetComponent<TrailRenderer>().enabled = false;
	}

	//void RestartLevel() {
	///	isRestarting = true;
		//Application.LoadLevel("Main");
	//}
}