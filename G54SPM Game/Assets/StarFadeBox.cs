using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFadeBox : MonoBehaviour
{
    public int lowerLimitInk;
    public int upperLimitInk;
    private float fullBoxHeight;

    void Start ()
    {
        fullBoxHeight = transform.localScale.y;
        transform.localScale = new Vector2(transform.localScale.x, 0);
	}

	void Update ()
    {
        int totalPointsUsed = 0;

        Line[] lines = FindObjectsOfType<Line>();
        foreach (Line line in lines)
        {
            totalPointsUsed += line.getNumPoints();
        }

        if(totalPointsUsed > upperLimitInk)
        {
            transform.localScale = new Vector2(transform.localScale.x, fullBoxHeight);
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }

        else if(totalPointsUsed > lowerLimitInk)
        {
            float boxHeight = (totalPointsUsed - lowerLimitInk) * fullBoxHeight / (upperLimitInk - lowerLimitInk);

            transform.localScale = new Vector2(transform.localScale.x, boxHeight);
        }

        else
        {
            transform.localScale = new Vector2(transform.localScale.x, 0);
        }
	}
}
