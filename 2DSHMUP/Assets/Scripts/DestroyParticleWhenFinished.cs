using UnityEngine;
using System.Collections;

public class DestroyParticleWhenFinished : MonoBehaviour 
{

	void Update () 
	{
		if(!particleSystem.isPlaying)
		{
			Destroy(gameObject);
		}
	}
}
