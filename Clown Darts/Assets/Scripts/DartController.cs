using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartController : MonoBehaviour
{
    public DartSpawner Spawner;
	public float postFlightControlTime = 2.0f;
	public float CameraReverseRate = 10.0f;

	private bool postFlight = false;

	// Update is called once per frame
	void Update ()
    {
		if (postFlight)
		{
			// Move up while locking onto the focus dart
			Vector3 lookAtVector = transform.forward;
			transform.position += lookAtVector * - 1.0f * Time.deltaTime * CameraReverseRate;

			transform.rotation = Quaternion.LookRotation(lookAtVector);

			return;
		}

		// Release baby darts and detach from the daddy dart
		if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Release mini darts!");
            Spawner.gameObject.SetActive(true);
        }
	}

	public void NotifyFlightFinished()
	{
		postFlight = true;
		Invoke("ReturnControlToCannon", postFlightControlTime);
	}

	public void ReturnControlToCannon()
	{
		GetComponentInChildren<Camera>().enabled = false;
		GameManager.GetInstance().ReturnControlToCannon();

		Destroy(gameObject);
	}
}
