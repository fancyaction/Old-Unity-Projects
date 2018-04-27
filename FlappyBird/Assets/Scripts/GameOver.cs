using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	float gameOverCooldown = 1f;
	BirdMovement bird;

	// Use this for initialization
	void Start () {
	
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		bird = player_go.GetComponent<BirdMovement>();
	}
	
	// Update is called once per frame
	void Update () {

		if (bird.dead) {
			gameOverCooldown -= Time.deltaTime;
			if(gameOverCooldown <= 0) {
				gameOverCooldown -= Time.deltaTime;
				GetComponent<SpriteRenderer>().enabled = true;
			
				if(Input.GetMouseButtonDown(0)) {
					GetComponent<SpriteRenderer>().enabled = false;
				}
			}
		}
	}

}