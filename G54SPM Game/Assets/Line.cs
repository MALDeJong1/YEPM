using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public float floatDistance = .1f;
   // private GameObject gameController;

    /*
        To calculate the amount of ink used, use the floatDistance variable * the list's points.Count
        Send this to the MasterScript, which will keep track of it.
     */

    List<Vector2> points;

    void Start()
    {
       // gameController = GameObject.Find("GameController");
    }

    //Function is public because it needs to be accessed by the 
    //Script that will be creating the lines. 
    //Will be called while we're still updating the line.
    public void UpdateLine(Vector2 mousePosition)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePosition);
            return;
        }
        // If points List is already set up and this is not the first point.
        // Check if the mouse has moved enough to need to insert new point.
        // If it has, insert point at mouse position.
        if (Vector2.Distance(points.Last(), mousePosition) > floatDistance)
            SetPoint(mousePosition);
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point); //Add mouse position onto the end of the list.

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
            edgeCollider.points = points.ToArray();
    }

    void Update()
    {
        if (!MasterScript.playingState && Input.GetKeyDown(KeyCode.C)) //Ifall lines are removed...
        {
            MasterScript.FillInkResource(); //Refill the ink resource back to full.
            Destroy(this.gameObject); // Destroy all lines.
        }
    }
}