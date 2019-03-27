using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The main Enemy script.
/// Contains configurable movement functionality for enemies.
/// </summary>
public class EnemyScript : MonoBehaviour {

    // Public variables, animation curve for the animation, and x and y variables
    // to determine how far in each direction the enemy should move during the animation loop.
    public AnimationCurve ac;
    public float movementDisY;
    public float movementDisX;

    // Two private vectors used to calculate movement.
    // The first holds the enemy's initial position, the second will hold the calculated end position.
    // The Coroutine will hold the movement loop so it can be stopped when game is not in playing state.
    private Vector3 startPos;
    private Vector3 endPos;
    private Coroutine movementRoutine = null;

	/// <summary>
    /// Initialises a start and end position for the enemy.
    /// End position is determined by current position + movement in X or Y directions.
    /// </summary>
	void Start ()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        endPos = new Vector3(transform.position.x + movementDisX, transform.position.y + movementDisY, transform.position.z);
	}
	
	/// <summary>
    /// Starts or stops the enemy's movement depending on whether the game is in playingState or not.
    /// </summary>
	void Update ()
    {
        if (MasterScript.playingState)
        {
            if (movementRoutine == null)
            {
                movementRoutine = StartCoroutine(Move(startPos, endPos, ac, 3.0f));
            }
        }
        if (!MasterScript.playingState)
        {
            if (movementRoutine != null)
            {
                StopCoroutine(movementRoutine);
                transform.position = startPos;
                movementRoutine = null;
            }
        }
    }

    /// <summary>
    /// Calculates the enemy's movement.
    /// </summary>
    /// <param name="startPos">The initial starting position of the enemy.</param>
    /// <param name="endPos">The desired end position of the enemy.</param>
    /// <param name="ac">The animation curve, used to calculate movement.</param>
    /// <param name="time">The time, used to determine movement.</param>
    /// <returns></returns>
    IEnumerator Move(Vector3 startPos, Vector3 endPos, AnimationCurve ac, float time)
    {
        float timer = 0.0f;
        while (true)
        {
            transform.position = Vector3.Lerp(startPos, endPos, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
    }

}
