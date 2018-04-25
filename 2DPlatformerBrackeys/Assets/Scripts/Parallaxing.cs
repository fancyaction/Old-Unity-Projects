using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour 
{
	public Transform[] backgrounds;				//Array of back- & foregrounds to be parallaxed.
	private float[] parallaxScales;				//How much to move backgrounds
	public float smoothing = 1f;	

	private Transform cam;						//reference to main camera's transform
	private Vector3 previousCamPos;				//stores position in last frame

	//Called before Start()
	void Awake () 
	{
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () 
	{
		previousCamPos = cam.position;

		parallaxScales = new float[backgrounds.Length];

		for(int i = 0; i < backgrounds.Length; i++) 
		{
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < backgrounds.Length; i++)
		{
			//Parallax is opposite of camera movement; previous frame * scale
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			// set a target x position which is the current position plus parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			//create a target position which is the background's current position + target x position.
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			//fade between current and target position with lerp
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		//set previousCamPos to position at frame's end
		previousCamPos = cam.position;
	}
}
