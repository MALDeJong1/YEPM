using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour {

    // Variable to keep track of whether the gam e is currently in its set up or playing state.
    // If set to true, the game's objects will move and the player character will be affected by gravity.
    public bool playingState = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Below commented out code changes value of playingState when space is pressed.
        // Refactor for proper implementation of state change, including a level reset when it
        // cycles back from true to false. 
       if (Input.GetKeyDown("space"))
        {
            if (playingState)
            {
                playingState = false;
            }
            else
            {
                playingState = true;
           }
        } 
    }


}
