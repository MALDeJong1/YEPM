using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    // Public variables, animation curve for the animation, and two floats for the x and y movements of the enemy.
    public AnimationCurve ac;
    public float movementDisY;
    public float movementDisX;

    //Two private vectors. The first is the enemy's movement start position, the second is the movement end position.
    private Vector3 startPos;
    private Vector3 endPos;
    private Coroutine movementRoutine = null;
    
    //Keep track of whether the enemy is moving.
    private bool moving = false;

	// Use this for initialization
	void Start ()
    {
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        endPos = new Vector3(transform.position.x + movementDisX, transform.position.y + movementDisY, transform.position.z);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (MasterScript.playingState)
        {
            if (movementRoutine == null)
            {
                movementRoutine = StartCoroutine(Move(startPos, endPos, ac, 3.0f));
                moving = true;
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
