using System.Collections;
using UnityEngine;

public class MasterScript : MonoBehaviour {

    public static MasterScript gameController;
    public static bool playingState = false;    //Keeps trackof whether the game is currently in set up or playing stage.

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
    public Transform spawnEffect;
    public int spawnDelay = 1;

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
    public IEnumerator RespawnPlayer()
    {
        Debug.Log("Respawn has been called.");
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(spawnEffect, spawnPoint.position, spawnPoint.rotation);
        Instantiate(playerCharacter, spawnPoint.position, spawnPoint.rotation);
        playingState = false; //Return to drawing state.
    }

    // Function to kill the player. Destroys the player object and calls respawn to spawn new player object.
    public static void KillPlayer(PlayerController player)
    {
        Debug.Log("KillPlayer was called.");
        Destroy(player.gameObject);
        //gameController.RespawnPlayer();
        gameController.StartCoroutine(gameController.RespawnPlayer());
    }

    // Function to set ink resource back to full.
    public static void FillInkResource()
    {
        gameController.ink = 100;
    }

}
