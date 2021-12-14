using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoToSettingMenu()
    {
        SceneManager.LoadScene("HighScore");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
   public void QuitGame()
    {
      Application.Quit();  
    }
}
