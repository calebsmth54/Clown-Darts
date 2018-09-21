using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
	public GameObject ClownPrefab;
	public GameObject[] allBalloonPrefabs;

	public GameObject[] balloonSpawnPoints;
	public GameObject[] eitherSpawnPoints;

	int result;
	private GameObject balloonie;
	private GameObject clownie;
	// Use this for initialization
	void Start () {
		
		foreach (GameObject spot in balloonSpawnPoints) {
			result = Random.Range (-1, allBalloonPrefabs.Length);
			if (result == -1) {
				//do nothing
			} else {
				balloonie = Instantiate (allBalloonPrefabs [result]);
				balloonie.transform.parent = spot.transform;
				balloonie.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
			}

		}
		foreach (GameObject spot in eitherSpawnPoints) {
			result = Random.Range (-1, (1 + allBalloonPrefabs.Length));
			if(result == -1){
				break;
			}
			if (result > 0) {
				result -= 1;
				 balloonie = Instantiate (allBalloonPrefabs [result]);
				balloonie.transform.parent = spot.transform;
				balloonie.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
			} else {
				clownie = Instantiate (ClownPrefab);
				clownie.transform.parent = spot.transform;
				balloonie.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
			}

		}
	}


}
