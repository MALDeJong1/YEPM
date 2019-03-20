using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to handle Player related logic.
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Sound effect related variables.
    public AudioSource fallNoise;
    public AudioSource eatingNoise;

    // Player's rigidbody.
    private Rigidbody2D rb;

    /// <summary>
    /// Initialises the player's rigidbody component.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Sets player to be affected by gravity depending on whether the game is in its playing state or not.
    /// Checks if player is still within the boundaries set in the MasterController, and kills them if not.
    /// </summary>
    void Update()
    {
        if (MasterScript.playingState)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        if (!MasterScript.playingState)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }

        // If the player is out of bounds, kill them.
        if(transform.position.y <= MasterScript.minY || transform.position.y >= MasterScript.maxY || transform.position.x <= MasterScript.minX || transform.position.x >= MasterScript.maxX)
        {
            fallNoise.Play();
            Debug.Log("Player has gone out of bounds.");
            MasterScript.KillPlayer(this);
        }
    }

    /// <summary>
    /// Checks whether collision is with an enemy and kills the player if so.
    /// </summary>
    /// <param name="collision">The GameObject that collision occurred with.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy" || collision.gameObject.tag == "Enemy")
        {
            eatingNoise.Play();
            MasterScript.KillPlayer(this);
        }
    }
}
