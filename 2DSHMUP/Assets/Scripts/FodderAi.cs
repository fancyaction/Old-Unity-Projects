using UnityEngine;
using System.Collections;

public class FodderAi : MonoBehaviour 
{
	public float speed = 1.0f;
	public float sinAmplitude = 1.0f;
	public float sinFrequency = 1.0f;
	private float horizontalOffest = 0.0f;
	private float time;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		time += Time.deltaTime;

		//Remove offset from enemy
		transform.position -= horizontalOffest*transform.right;

		//Moves enemy forward
		transform.position += transform.forward*speed*Time.deltaTime;

		//Adjust horziontal position by sine wave
		horizontalOffest = Mathf.Sin (time*sinFrequency*2*Mathf.PI)*sinAmplitude;

		transform.position += horizontalOffest*transform.right;
	}
}
