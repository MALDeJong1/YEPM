using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The class that handles much of the overarching game logic.
/// </summary>
public class MasterScript : MonoBehaviour {

    // Public variables with general, overarching use.
    public static MasterScript gameController;
    public static bool playingState = false;    //Keeps track of whether the game is currently in set up or playing stage.
    public AudioSource respawnNoise;

    // Boundary Variables - if the player goes out of these bounds, they die.
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

    /// <summary>
    ///     Instantiates MasterScript and spawns initial Player Character.
    /// </summary>
    void Start () {
        if (gameController == null)
        { 
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MasterScript>();
            SpawnPlayer();
        }     		
	}

    /// <summary>
    /// Checks for space or r presses. Will set the game's playing state to true on space, and reset the full level on r.
    /// </summary>
    void Update () {
       if (Input.GetKeyDown("space"))
        {
            if (!playingState)
            {
                playingState = true;
           }
        } 
       if (Input.GetKeyDown("r"))
        {
            if (playingState) // Only reset if the game is in playing state.
                ResetLevel();
        }
    }

    /// <summary>
    /// Spawns the player on the spawnPoint position.
    /// </summary>
    public void SpawnPlayer() 
    {
        Instantiate(playerCharacter, spawnPoint.position, spawnPoint.rotation);
    }

    /// <summary>
    /// Respawns player on spawnPoint if they die after a short delay.
    /// </summary>
    /// <returns>Delay until respawn.</returns>
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

    /// <summary>
    /// Kills (destroys) the player object and calls RespawnPlayer to bring them back to life.
    /// </summary>
    /// <param name="player">Player GameObject</param>
    public static void KillPlayer(PlayerController player)
    {
        Debug.Log("KillPlayer was called.");
        Destroy(player.gameObject);
        gameController.StartCoroutine(gameController.RespawnPlayer());
    }

    /// <summary>
    /// Transitions the game to the nxt level.
    /// </summary>
    public static void LevelTransition()
    {
        playingState = false; // We will no longer be in playingState because the player has won the level.
        gameController.StartCoroutine(gameController.LoadNextLevel());
    }

    /// <summary>
    /// Loads the next level provided there is one.
    /// </summary>
    /// <returns> Delay until next level is loaded. </returns>
    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(levelTransitionDelay);
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    /// <summary>
    /// Resets the level entirely.
    /// </summary>
    private void ResetLevel()
    {
        playingState = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
