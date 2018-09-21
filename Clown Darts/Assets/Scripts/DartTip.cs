using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTip : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		// Ignore collision from our parent
		if (other.CompareTag("Dart") || other.CompareTag("NoPenetration"))
			return;

		// Grab our dart body
		Dart parentDart = GetComponentInParent<Dart>();

		if (other.CompareTag("Balloon")) //poppin' time
        {
            other.GetComponentInParent<Balloon>().DartPop();
        }
		else if (other.CompareTag("Bullseye"))
		{
			other.GetComponent<Bullseye>().Scored(parentDart);

		}

		if (!parentDart)
		{
			Debug.LogError("Dart tip doesn't have a body!");
			return;
		}

		// Tell our dart body about this collision
		parentDart.DartTipCollision(other.gameObject);
	}
}
