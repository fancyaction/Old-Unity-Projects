using UnityEngine;
using System.Collections;

//Relative rotation!
public class RotateBackAndForth2D : MonoBehaviour 
{
	public float startRotation = 0;
	public float endRotation = 90;
	public float rotationTime = 0.5f;


	void Start () 
	{
		StartCoroutine("RotateForth");
	}

	IEnumerator RotateForth()
	{
		float t = 0.0f;

		while(t < rotationTime)
		{
			transform.RotateAround(transform.position,transform.up,Time.deltaTime*(endRotation - startRotation));
			t += Time.deltaTime;
			yield return null;
		}

		StartCoroutine("RotateBack");
	}
	
	IEnumerator RotateBack()
	{
		float t = 0.0f;
		
		while(t < rotationTime)
		{
			transform.RotateAround(transform.position,transform.up,-Time.deltaTime*(endRotation - startRotation));
			t += Time.deltaTime;
			yield return null;
		}

		StartCoroutine("RotateForth");
	}
}
