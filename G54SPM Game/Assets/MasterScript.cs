using System.Collections;
using UnityEngine;

public class MasterScript : MonoBehaviour {

    public static MasterScript gameController;
    public static bool playingState = false;    //Keeps trackof whether the game is currently in set up or playing stage.
    public static int spawnDelay = 2;

    // Boundary Variables
    public static int minY = -8;
    public static int maxY = 8;
    public static int minX = -16;
    public static int maxX = 16;

    // Basic Game Logic Variables
    private int ink; //Stores ink resource.

    // Respawn Variables
    public Transform playerCharacter;
    public Transform spawnPoint;

    // Instantiates MasterScript and spawns initial Player Character.
    void Start () {
        if (gameController == null)
        { 
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MasterScript>();
            SpawnPlayer();
            FillInkResource();
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

    // Initial function for spawning player at respawn position.
    public void SpawnPlayer() 
    {
        Instantiate(playerCharacter, spawnPoint.position, spawnPoint.rotation);
    }

    // Function for respawning player after player death.
    public void RespawnPlayer()
    {
        Instantiate(playerCharacter, spawnPoint.position, spawnPoint.rotation);
        playingState = false;
        //Debug.Log("Particles go here!");
    }

    // Function to kill the player. Destroys the player object and calls respawn to spawn new player object.
    public static void KillPlayer(PlayerController player)
    {
        Destroy(player.gameObject);
        gameController.RespawnPlayer();
    }

    // Function to set ink resource back to full.
    public static void FillInkResource()
    {
        gameController.ink = 100;
    }

}
