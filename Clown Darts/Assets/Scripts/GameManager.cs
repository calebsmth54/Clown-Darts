using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager globalManager;

	public Camera MainCamera;
	public PlayerUI playerUI;
	public HighScoreEntry highScoreUI;

	public float powerRate = 0.125f;
	private float currentPower = 0.0f;
	private bool powerHeld = false;
	public int startingDarts = 12;

	public bool dartInFlight = false;
	public Gun Cannon;

	private int playerScore = 0;
	private int[] savedScores;
	private string[] savedInitials;
	private int newHighScoreIndex;

	public static GameManager GetInstance()
	{
		return globalManager;
	}

	public int[] GetHighScores()
	{
		if (savedScores == null)
		{
			savedScores = new int[10];

			// Deserialize high scores
			for (int x = 9; x >= 0; x--)
			{
				savedScores[x] = PlayerPrefs.GetInt("HighScoreValue" + x.ToString(), 0);
			}
		}

		return savedScores;
	}

	public string[] GetHighScoreInitials()
	{
		if (savedInitials == null)
		{
			savedInitials = new string[10];

			// Deserialize high scores
			for (int x = 9; x >= 0; x--)
			{
				savedInitials[x] = PlayerPrefs.GetString("HighScoreInitial" + x.ToString(), "AAA");
			}
		}

		return savedInitials;
	}

	public void SaveScores()
	{
		// Serialize high scores
		for (int x = 9; x >= 0; x--)
		{
			PlayerPrefs.SetInt("HighScoreValue" + x.ToString(), savedScores[x]);
			PlayerPrefs.SetString("HighScoreInitial" + x.ToString(), savedInitials[x]);
		}
	}

	// Use this for initialization
	void Start ()
	{
		if (!globalManager)
			globalManager = this;

		GetHighScores();
		GetHighScoreInitials();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (powerHeld)
		{
			if (currentPower >= 1.0f)
				currentPower = 0.0f;

			currentPower = Mathf.Min(1.0f, currentPower + powerRate * Time.deltaTime);

			// Notify UI
			playerUI.NewPowerLevel(currentPower);
		}
	}

	public void ReturnControlToCannon()
	{
		MainCamera.GetComponentInChildren<Camera>().enabled = true;

		dartInFlight = false;
		Cannon.ReturnControlToGun();
	}

	public void NotifyPowerHeld()
	{
		powerHeld = true;
		currentPower = 0.0f;
	}

	public float NotifyPowerReleased()
	{
		MainCamera.GetComponentInChildren<Camera>().enabled = false;

		powerHeld = false;
		dartInFlight = true;

		// Let the UI know we fired a dart
		playerUI.DartFired();

		return currentPower;
	}

	public void NotifyOfScore(int newScore)
	{
		playerScore += newScore;
		playerUI.UpdateScore(playerScore);
	}

	public void NotifyOutOfDarts()
	{
		Debug.Log("No more darts :/");
		playerUI.gameObject.SetActive(false);

		// Compare with previous high scores
		// If we are between two scores, save this one
		int x = -1;
		while (x < 9 && playerScore > savedScores[x+1])
		{
			x++;
		}

		if (x >= 0)
		{
			// Place our new high score here
			newHighScoreIndex = x;
			highScoreUI.ShowNewHighScore(playerScore);
		}

		else
		{
			ReturnToMainMenu();
		}
	}

	public void SubmitNewScore(string initials)
	{
		// shift high scores down
		for( int x = 0; x < newHighScoreIndex; x++)
		{
			savedScores[x] = savedScores[x+1];
			savedInitials[x] = savedInitials[x+1];
		}

		// Add our new high score
		savedScores[newHighScoreIndex] = playerScore;
		savedInitials[newHighScoreIndex] = initials;

		SaveScores();

		ReturnToMainMenu();
	}

	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene(0);
	}
}
