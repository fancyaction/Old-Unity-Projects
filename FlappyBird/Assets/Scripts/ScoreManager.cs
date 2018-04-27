using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	static int score = 0;
	static int highScore = 0;

	static ScoreManager instance;

	static public void AddPoint() {
		if(instance.bird.dead)
			return;

		score++;

		if(score > highScore) {
			highScore = score;
		}
	}

	BirdMovement bird;

	void Start() {
		instance = this;
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if(player_go == null) {
			Debug.LogError("Could not find an object with tag 'Player'.");
		}

		bird = player_go.GetComponent<BirdMovement>();
		score = 0;
		highScore = PlayerPrefs.GetInt("highscore", 0);
	}

	void OnDestroy() {
		instance = null;
		PlayerPrefs.SetInt("highscore", highScore);
	}

	void Update () {
		guiText.text = "Score: " + score + "\n High score: " + highScore;
	}
}
