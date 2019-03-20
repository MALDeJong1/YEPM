using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource failNoise;
    public AudioSource eatingNoise;
    private Rigidbody2D rb;
    //private GameObject gameController;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //gameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
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

        //Check whether player is out of the bounds defined in the GameController's Masterscript. If so, kill the player.
        if(transform.position.y <= MasterScript.minY || transform.position.y >= MasterScript.maxY || transform.position.x <= MasterScript.minX || transform.position.x >= MasterScript.maxX)
        {
            failNoise.Play();
            Debug.Log("Player has gone out of bounds.");
            MasterScript.KillPlayer(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy" || collision.gameObject.tag == "Enemy")
        {
            eatingNoise.Play();
            MasterScript.KillPlayer(this);
        }
    }
}
