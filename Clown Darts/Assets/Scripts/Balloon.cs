using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Attach script to balloon gameobject to add dart collision detection and poppage
/// </summary>
public class Balloon : MonoBehaviour
{
	public int BalloonScore = 25;

    public void DartPop() //called by DartTip on collision w/ balloon collider
    {
        // destroy mesh
        // particle effect "CONFETTI!"
        PopSound();

		GetComponent<MeshRenderer>().enabled = false;
		GameManager.GetInstance().NotifyOfScore(BalloonScore);
		GetComponent<SphereCollider>().enabled = false;
		Destroy(gameObject, 5.0f);
    }

    public void PopSound()
    {
        GetComponent<AudioSource>().Play();
    }
}
