using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOBarker : MonoBehaviour {

	public AudioClip[] clipsToPlay;
	public AudioSource source;
	private List<AudioClip> randomShuffle;

	// Use this for initialization
	void Start ()
	{
		randomShuffle = new List<AudioClip>();
	}

	public void BarkSomething()
	{
		// Reshuffle our list
		if(randomShuffle.Count <= 0)
		{
			while (randomShuffle.Count < clipsToPlay.Length)
			{
				int randomIndex = Random.Range(0, clipsToPlay.Length);
				randomShuffle.Add(clipsToPlay[randomIndex]);
			}
		}

		AudioClip selectedClip = randomShuffle[0];
		randomShuffle.RemoveAt(0);

		source.clip = selectedClip;
		source.Play();
	}
}
