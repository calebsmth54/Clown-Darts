using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSpawner : MonoBehaviour
{
    public GameObject DartPrefab;
    public float randomForceRange = 0.5f;
    public int numberOfDarts = 12;
    private List<GameObject> childDartList;

    private void Start()
    {
        childDartList = new List<GameObject>();

        // Create all our child darts
        for( int x = 0; x < numberOfDarts; x++)
        {
            GameObject newDart = Instantiate(DartPrefab, transform.position, Quaternion.AngleAxis(-90.0f, Vector3.forward));

            float randMagnitdue = Random.Range(0.0f, randomForceRange);
            Vector3 randDirection = Random.onUnitSphere;
            randDirection.z = 0.0f;
            Vector3 randForce = randDirection * randMagnitdue;

			// Pass on our parents momentum - physics!
			Vector3 parentVelocity = GetComponentInParent<Rigidbody>().velocity;
			newDart.GetComponent<Rigidbody>().AddForce(parentVelocity, ForceMode.VelocityChange);

			// Push our dart in a radom direction on the right-up plane
			newDart.GetComponent<Rigidbody>().AddForce(randForce, ForceMode.Impulse);

            childDartList.Add(newDart);
        }
    }
}
