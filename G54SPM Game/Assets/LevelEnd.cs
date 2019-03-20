using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

    public GameObject levelEndText;
	
    // Use this for initialization
	void Start ()
    {
        levelEndText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelEndText.SetActive(true);
        //ADD DELAY HERE
        MasterScript.LevelTransition();
    }
}
