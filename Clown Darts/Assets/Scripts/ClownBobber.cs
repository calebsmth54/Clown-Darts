using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownBobber : MonoBehaviour
{
	public int Score = 50;
	public Transform pivot;
	private Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		rb.centerOfMass = pivot.localPosition;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Dart"))
		{
			GameManager.GetInstance().NotifyOfScore(Score);
		}
	}


}
