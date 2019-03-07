using System.Collections;
using UnityEngine;

public class MasterScript : MonoBehaviour {

    public static MasterScript gameController;
    public static bool playingState = false;    //Keeps trackof whether the game is currently in set up or playing stage.
    public static int spawnDelay = 2;
    public static int minY = -8;
    public static int maxY = 8;
    public static int minX = -16;
    public static int maxX = 16;

	// Use this for initialization
    // We ensure there is only ever one instance of the MasterScript running.
	void Start () {
        if (gameController == null)
        { 
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MasterScript>();
            RespawnPlayer();
        }     		
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

    public Transform playerCharacter;
    public Transform spawnPoint;

    public void RespawnPlayer()
    {
        Instantiate(playerCharacter, spawnPoint.position, spawnPoint.rotation);
        playingState = false;
        //Debug.Log("Particles go here!");
        Debug.Log("Touched a boundary.");
    }

    public static void KillPlayer(PlayerController player)
    {
        Destroy(player.gameObject);
        gameController.RespawnPlayer();
    }


}
