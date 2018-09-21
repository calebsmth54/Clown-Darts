using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullseye : MonoBehaviour
{
	public int BullseyeMaxScore = 100;
	
	public void Scored(Dart dart)
	{
		// Get percent to center of bullseye
		BoxCollider collider = GetComponent<BoxCollider>();

		float colliderRadius = collider.size.x;
		Vector3 vectorToBullseye = (transform.position - dart.transform.position);
		vectorToBullseye.y = 0;
		float distToBullseye = vectorToBullseye.magnitude;

		Debug.Log("Radius: " + colliderRadius + " Distance to Bullseye: " + distToBullseye);
		float percentToCenter = distToBullseye / colliderRadius;

		// Update score
		GameManager.GetInstance().NotifyOfScore((int)(BullseyeMaxScore * percentToCenter));
	}
}
