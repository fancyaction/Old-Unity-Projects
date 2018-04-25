using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour 
{
	public int offsetX = 2; //prevents errors

	public bool hasRightBuddy = false; //checks whether instantiate is necessary
	public bool hasLeftBuddy = false;

	public bool reverseScale = false; //used if object isn't tilable

	private float spriteWidth = 0f; //width of element
	private Camera cam;
	private Transform myTransform;

	void Awake () 
	{
		cam = Camera.main;
		myTransform = transform;
	}

	// Use this for initialization
	void Start () 
	{
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
		spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hasLeftBuddy == false || hasRightBuddy == false) //does it still need buddys? If not, do nothing
		{
			//calculate the camera's extend (width/2) of what the camera can see in world coordinates
			float camHorizontalExtend = cam.orthographicSize * Screen.width/Screen.height;

			//calculate the x position where the camera can see the edge of the sprite/element
			float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth/2) - camHorizontalExtend;
			float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth/2) + camHorizontalExtend;

			//checking if element edge is visible and then calling MakeNewBuddy if possible
			if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasRightBuddy == false)
			{
				MakeNewBuddy (1);
				hasRightBuddy = true;
			}

			else if(cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasLeftBuddy == false)
			{
				MakeNewBuddy (-1);
				hasLeftBuddy = true;
			}
		}
	}

		//creates buddy on side required
		void MakeNewBuddy (int rightOrLeft) 
		{
			//calculating new posiiton for new buddy
			Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
			//Instantiating new buddy and storing in variable
			Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;

			//if not tilable, reverse x size of object to blend smoothly
			if (reverseScale == true) 
			{
				newBuddy.localScale = new Vector3 (newBuddy.localScale.x*-1,newBuddy.localScale.y,newBuddy.localScale.z);
			}

			newBuddy.parent = myTransform.parent;

			if (rightOrLeft > 0)
			{
				newBuddy.GetComponent<Tiling>().hasLeftBuddy = true;
			}

			else 
			{
				newBuddy.GetComponent<Tiling>().hasRightBuddy = true;
			}
		}
}
