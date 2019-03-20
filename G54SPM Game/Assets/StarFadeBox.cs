using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFadeBox : MonoBehaviour
{
    public int lowerLimitInk; // Integer corresponding to the amount of ink used when the star will start fading
    public int upperLimitInk; /* Integer corresponding to the amount of ink used when the star will have fully faded
    and will turn completely white*/

    private float fullStarHeight;
    private int totalPointsUsed;

    void Start ()
    {
        fullStarHeight = transform.localScale.y;
        transform.localScale = new Vector2(transform.localScale.x, 0);
	}

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
