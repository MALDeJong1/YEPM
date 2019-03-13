using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBox : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        collider.attachedRigidbody.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
        Debug.Log("SpringBox hit");
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
