using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	public Slider PowerSlider;
	public Text ScoreText;
	public Text DartText;

	private int dartCount;

	// Use this for initialization
	void Start ()
	{
		dartCount = GameManager.GetInstance().startingDarts;
		DartText.text = dartCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NewPowerLevel(float powerLevel)
	{
		PowerSlider.value = powerLevel;
	}

	public void UpdateScore(int playerScore)
	{
		ScoreText.text = playerScore.ToString();
	}

	public void DartFired()
	{
		dartCount--;
		DartText.text = dartCount.ToString();
	}
}
