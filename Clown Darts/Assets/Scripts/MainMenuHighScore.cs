using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHighScore : MonoBehaviour {

    public GameObject MainMenu;
	public Text[] Scores;
	public Text[] Initials;

	public void Start()
	{
		for (int x = 0; x < 10; x++)
		{
			// This is not a good way of writing this...
			Scores[x].text = GameManager.GetInstance().GetHighScores()[x].ToString();
			Initials[x].text = GameManager.GetInstance().GetHighScoreInitials()[x].ToString();
		}
	}

	public void BackButton()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
