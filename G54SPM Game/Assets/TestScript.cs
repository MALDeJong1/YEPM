using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    private Rigidbody2D rb;
    private MasterScript masterScript;
    private GameObject gameController;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.Find("GameController");
        masterScript = gameController.GetComponent<MasterScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (masterScript.playingState)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        if (!masterScript.playingState)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }	
	}
}
