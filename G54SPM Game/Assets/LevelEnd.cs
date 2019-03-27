using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script that holds functions pertaining to level endings.
/// Determines whether the congratulatory level end text is visible or invisible, and can call scene transitions.
/// </summary>
public class LevelEnd : MonoBehaviour {

    // Public variable to hold the necessary text element to be displayed on level ending.
    public GameObject levelEndText;
	
    /// <summary>
    /// Initialises the congratulatory level end text to be invisible.
    /// </summary>
	void Start ()
    {
        levelEndText.SetActive(false);
	}

    /// <summary>
    /// Should be called when a level's win condition is reached.
    /// Sets the congratulatory level end text to visible. 
    /// Will invoke the MasterScript to trigger a level transition.
    /// </summary>
    /// <param name="collision">The GameObject that collided with this GameObject.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelEndText.SetActive(true);
        MasterScript.LevelTransition();
    }
}
