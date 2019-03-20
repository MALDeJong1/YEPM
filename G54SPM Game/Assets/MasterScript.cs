using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterScript : MonoBehaviour {

    public static MasterScript gameController;
    public static bool playingState = false;    //Keeps trackof whether the game is currently in set up or playing stage.
    public AudioSource respawnNoise;

    // Boundary Variables
    public static int minY = -8;
    public static int maxY = 8;
    public static int minX = -16;
    public static int maxX = 16;

    // Respawn Variables
    public Transform playerCharacter;
    public Transform spawnPoint;
    public Transform spawnEffect;
    public int spawnDelay = 1;

    // Load next level Variables
    public int levelTransitionDelay = 2;

    // Instantiates MasterScript and spawns initial Player Character.
    void Start () {
        if (gameController == null)
        { 
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MasterScript>();
            SpawnPlayer();
        }     		
	}

    // Update is called once per frame
    void Update () {
        // Below ccode changes value of playingState when space is pressed.
        // Refactor for proper implementation of state change, including a level reset when it
        // cycles back from true to false. 
       if (Input.GetKeyDown("space"))
        {
           /* if (playingState)
            {
                playingState = false;
            }*/
            if (!playingState)
            {
                playingState = true;
           }
        } 
       if (Input.GetKeyDown("r")) //Keybinding for resetting the level.
        {
            if (playingState)
                ResetLevel();
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

        respawnNoise.Play();
        GameObject effectClone = Instantiate(spawnEffect, spawnPoint.position, spawnPoint.rotation).gameObject;
        Instantiate(playerCharacter, spawnPoint.position, spawnPoint.rotation);
        Destroy(effectClone, 3f);
        playingState = false; //Return to drawing state.
    }

    // Function to kill the player. Destroys the player object and calls respawn to spawn new player object.
    public static void KillPlayer(PlayerController player)
    {
        Debug.Log("KillPlayer was called.");
        Destroy(player.gameObject);
        gameController.StartCoroutine(gameController.RespawnPlayer());
    }

    // Function that is called when the player wins a level to transition to the next.
    public static void LevelTransition()
    {
        playingState = false; // No longer in playingState because the player has won the level.
        gameController.StartCoroutine(gameController.LoadNextLevel());
    }

    // Function that handles loading the next level, provided there is one.
    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(levelTransitionDelay);
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private void ResetLevel()
    {
        playingState = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
