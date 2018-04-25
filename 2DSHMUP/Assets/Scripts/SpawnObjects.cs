﻿using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour 
{
	public GameObject objectToSpawn;
	public float spawnDelay = 1.0f;

	// Use this for initialization
	void Start () 
	{
		Invoke("Spawn",spawnDelay);
	}
	
	// Update is called once per frame
	void Spawn () 
	{
		Instantiate(objectToSpawn,transform.position,transform.rotation);
		Invoke("Spawn",spawnDelay);
	}
}
