using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{

	public bool gameOver = false;
	
	void OnGUI()
	{
		if(gameOver)
		{
			GUILayout.Label("GAME OVER: Pree Enter to Reset");
		}
	}

	void Update() 
	{
		if(gameOver && Input.GetKeyDown(KeyCode.Return))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
	}
}