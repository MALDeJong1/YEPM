using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The line spawning script.
/// </summary>
public class LineSpawner : MonoBehaviour
{
    // Public variable for the linePrefab that is used to draw lines.
    public GameObject linePrefab;
    
    Line activeLine;

    /// <summary>
    /// Draws a line (using the linePrefab) if the game is in its playing state. Will not allow the drawing of lines if that is no longer so.
    /// </summary>
    void Update()
    {
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