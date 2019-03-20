using System.Linq;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script for instantiating lines, to be spawned by a LineSpawner.
/// </summary>
public class Line : MonoBehaviour
{
    // Public variables for lineRenderer, an edgeCollider so the player doesn't fall through drawn lines, and the minimum distance before mouse movement results in the addition of a new vertice.
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public float floatDistance = .1f;

    // A list of 2D vectors storing vertices between which lines can be drawn.
    List<Vector2> points;

    /// <summary>
    /// Returns the number of vertices in the points list.
    /// </summary>
    /// <returns>Number of vertices within the points list.</returns>
    public int getNumPoints()
    {
        return points.Count;
    }

    /// <summary>
    /// Will update existing line or draw a new one, based on whether there is currently an active line being drawn.
    /// </summary>
    /// <param name="mousePosition">Current mouse position</param>
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

    /// <summary>
    /// Adds the mouse position to the end of the current line's list, then adds edge collider to the emergent line. 
    /// </summary>
    /// <param name="point">Current mouse position</param>
    void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
            edgeCollider.points = points.ToArray();
    }

    /// <summary>
    /// Checks whether the c key is pressed while not in playing state, so the line knows whether to destroy itself.
    /// </summary>
    void Update()
    {
        if (!MasterScript.playingState && Input.GetKeyDown(KeyCode.C)) 
        {
            Destroy(this.gameObject); // Destroy all lines.
        }
    }
}