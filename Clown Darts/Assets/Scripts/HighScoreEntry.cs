using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreEntry : MonoBehaviour
{
	public GameObject HighScoreParent;
	public GameObject HighScoreCamera;

	public Text HighScoreText;

	public void ShowNewHighScore(int newScore)
	{
		HighScoreCamera.SetActive(true);
		HighScoreParent.SetActive(true);
		HighScoreText.text = newScore.ToString();
	}

	public void OnInitialsEntered(string initials)
	{
		GameManager.GetInstance().SubmitNewScore(initials);
	}
}
