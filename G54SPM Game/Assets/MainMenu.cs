using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Logic for the Game's Main Menu.
/// </summary>
public class MainMenu : MonoBehaviour {
    
    /// <summary>
    /// Will start the game.
    /// </summary>
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    /// <summary>
    /// Will close the application.
    /// </summary>
    public void QuitGame ()
    {
        Debug.Log("Quitting the game!");
        Application.Quit();
    }
}
