using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawner : MonoBehaviour
{

    public GameObject linePrefab;
    //private GameObject gameController;

    Line activeLine;

    // Use this for initialization
    void Start()
    {
       // gameController = GameObject.Find("GameController");
    }

    void Update()
    {
        //If the game is in its playingState, we're not allowed to draw any more lines. :)
        if (!MasterScript.playingState)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject lineGameObj = Instantiate(linePrefab);
                activeLine = lineGameObj.GetComponent<Line>();
            }

            if (Input.GetMouseButtonUp(0))
            {
                activeLine = null;
            }

            if (activeLine != null)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                activeLine.UpdateLine(mousePos);
            }
        }
    }
}