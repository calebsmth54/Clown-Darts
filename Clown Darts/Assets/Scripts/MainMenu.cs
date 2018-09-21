using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject HighScoreMenu;

    public void StartGamePressed()
    {
        SceneManager.LoadScene(1);        
    }
    
    public void OptionsPressed()
    {

    }

    public void LeaderboardPressed()
    {
        HighScoreMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitGamePressed()
    {
        Application.Quit();
    }
}
