using UnityEngine;
using System.Collections;

public class SeekingMissile : MonoBehaviour 
{
	public float initialVelocity = 10.0f;
	public float missileAccelerationForce = 10.0f;
	public float maxVelocity = 10.0f;
	private float maxSqrVelocity;

	private GameObject nearestEnemy;

	void Start () 
	{
		rigidbody.AddForce(transform.forward*initialVelocity,ForceMode.VelocityChange);

		float nearestDistance = Mathf.Infinity;
		nearestEnemy = null;
		
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			float distance = (transform.position - obj.transform.position).sqrMagnitude;
			
			// targets nearest enemy after initially drawing to inifinty for first enemy.
			if(distance < nearestDistance)
			{
				nearestDistance = distance;
				nearestEnemy = obj;
			}
		}
		maxSqrVelocity = maxVelocity*maxVelocity;
	}
	
	void FixedUpdate () 
	{
		if(nearestEnemy !=null)
		{
			transform.rotation = Quaternion.LookRotation(nearestEnemy.transform.position - transform.position,Vector3.back);
		}

		rigidbody.AddForce(transform.forward*missileAccelerationForce*Time.deltaTime,ForceMode.Acceleration);

		if(rigidbody.velocity.sqrMagnitude > maxSqrVelocity)
		{
			rigidbody.velocity = rigidbody.velocity.normalized*maxVelocity;
		}
	}
}
