using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour 
{

	public Texture2D fadeOutTexture; // texture that overlays screen. Black image or loading graphic
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;	//texture's place in hierarchy; low number renders on top
	private float alpha = 1.0f;		//texture's alpha value between 1 and 0
	private int fadeDir = -1;		//direction of scene's fade: in -1, out 1;

	void onGUI () 
	{
		//fade in/out alpha value using a direction, speed and Time.deltatime to converate to secs.
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		//force (clamp) number between 0 and 1 because GUI.color use alpha values between 0 and 1
		alpha = Mathf.Clamp01 (alpha);

		//set color of GUI(texture); all color values remain same and alpha is set to alpha variable.
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;	//black texture render on top (drawn last)
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); // draw texture to fit entire screen
	}

	//sets fadeDir to direction parameter making the scene fade in if -1 and out if 1
	public float BeginFade (int direction) 
	{
		fadeDir = direction;
		return (fadeSpeed); 	//return fadeSpeed variable so it's easy to time the Application.LoadLeve();
	}

	//OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a paramter so you can limit the fade in certain scenes
	void OnLevelWasLoaded () 
	{
		// alpha = 1  //use this if the alpha is not set to 1 by default
		BeginFade (-1);
	}
}
