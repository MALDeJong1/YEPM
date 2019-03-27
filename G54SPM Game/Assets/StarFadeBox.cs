using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to handle the fading of star rating based on length of drawn lines.
/// </summary>
public class StarFadeBox : MonoBehaviour
{
    // Public variables that denote the amount of ink needed for a star to begin fading, and to be fully gone and turned white.
    public int lowerLimitInk; 
    public int upperLimitInk;

    // Private variables to keep track of total number of vertices used in lines and the height of stars.
    private float fullStarHeight;
    private int totalPointsUsed;

    /// <summary>
    /// Initialises the starheight for later transformations.
    /// </summary>
    void Start ()
    {
        fullStarHeight = transform.localScale.y;
        transform.localScale = new Vector2(transform.localScale.x, 0);
	}

    /// <summary>
    /// Checks how many points have been used, whether that hits an ink limit, and fade stars accordingly.
    /// </summary>
	void Update ()
    {
        totalPointsUsed = 0; // Reset total points used, this will need to be recalculated each frame

        Line[] lines = FindObjectsOfType<Line>();
        foreach (Line line in lines)
        {
            totalPointsUsed += line.getNumPoints(); // Recalculate total points used
        }

        if(totalPointsUsed > upperLimitInk)
        {
            transform.localScale = new Vector2(transform.localScale.x, fullStarHeight); // Cover star full height
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1); // Set cover to fully white
        }

        else if(totalPointsUsed > lowerLimitInk)
        {
            float coverStarScale = (totalPointsUsed - lowerLimitInk) * fullStarHeight / (upperLimitInk - lowerLimitInk);
            // Cover star scale linearly proportional to the amount of ink used

            transform.localScale = new Vector2(transform.localScale.x, coverStarScale);
        }

        else
        {
            transform.localScale = new Vector2(transform.localScale.x, 0);
            // If the amount of ink used is under lowerLimitInk, then the cover star does not appear
        }
	}
}
