using UnityEngine;
using System.Collections;

public class GibOnTrigger : MonoBehaviour 
{
	public GameObject gib = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter () 
	{
		if(gib != null)
		{
			Instantiate(gib,transform.position,gib.transform.rotation);
		}
		Destroy (gameObject);
	}
}
