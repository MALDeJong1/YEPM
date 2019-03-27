using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script used for the SpringBox item.
/// </summary>
public class SpringBox : MonoBehaviour {
    
    // Variable to hold the spring's sound effect.
    public AudioSource springNoise;

    /// <summary>
    /// If a player impacts with the SpringBox, bounces them away and plays sound effect.
    /// </summary>
    /// <param name="collider">Collider on the GameObject that collided with this GameObject</param>
    void OnTriggerEnter2D(Collider2D collider)
    {
        collider.attachedRigidbody.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
        Debug.Log("SpringBox hit");
        springNoise.Play();
    }
}
