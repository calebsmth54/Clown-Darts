using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public AudioClip HitSound;
    public AudioSource HitSource;

	// Stick to this object if our dart tip is currently colliding with it
	private GameObject stickToObject;

	private Rigidbody dartRB;

	public void Start()
	{
		dartRB = GetComponent<Rigidbody>();
	}
	public void DartTipCollision(GameObject other)
	{
		stickToObject = other;
		Debug.Log("Our dart tip hit something!");
	}

	public void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Our body hit something");

		if (stickToObject)//&& !dud)
		{
			// Grab our rigidbody so we can turn off physics sim and stick to the object we just hit
			Rigidbody dartRB = GetComponent<Rigidbody>();

			transform.SetParent(stickToObject.transform, true);
			dartRB.useGravity = false;
			dartRB.isKinematic = true;

			Debug.Log("Our body stuck to " + stickToObject.name);

			// Hit the world Play our sfx

			HitSource.clip = HitSound;
			HitSource.Play();

			// Get rid of our collision
			CapsuleCollider[] dartColliders = GetComponentsInChildren<CapsuleCollider>();
			foreach (CapsuleCollider collider in dartColliders)
			{
				collider.enabled = false; // less memory thrashing?
										  //Destroy(collider);
			}
		}
		else
		{
			Debug.Log("Dud Dart");
			Destroy(gameObject, 20.0f); // Destroy these so they don't continue to float forever
		}

		// Let the controller know they can work again
		NotifyReturnControl();
	}

	public void FixedUpdate()
	{
		if (!stickToObject)
		{
			// Rotate towards our movement facing
			Vector3 movementDir = dartRB.velocity.normalized;

			transform.rotation = Quaternion.LookRotation(movementDir);
		}
	}

	private void NotifyReturnControl()
	{
		// Let our game manager know we're done flying
		DartController controller = GetComponentInChildren<DartController>();
		if (controller)
			controller.NotifyFlightFinished();
	}
}
