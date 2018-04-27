using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour {



	Transform Player;

	float offsetX;

	// Use this for initialization
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");

		if(player_go == null) {
			Debug.LogError("Couldn't find an object with tag 'Player'!");
			return;
		}

		Player = player_go.transform;

		offsetX = transform.position.x - Player.position.x;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Player != null) {
			Vector3 pos = transform.position;
			pos.x = Player.position.x + offsetX;
			transform.position = pos;
		}
	}
}
