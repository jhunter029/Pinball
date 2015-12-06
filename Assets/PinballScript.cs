using UnityEngine;
using System.Collections;

public class PinballScript : MonoBehaviour {
	public AudioClip plungerSfx;
	
	
	private AudioSource source;
	private Rigidbody rb; // game object's rigidbody reference
	public int thrust; // amount of force for plunger
	private  Vector3 startPos; // the starting position
	private bool plunger; // Bool to determine whether or not to add plunger force
	// Use this for initialization
	void Start () {
		// Get the starting transform in the plunger area
		startPos = transform.position;
		// Set the rigidbody reference variable
		rb = GetComponent<Rigidbody>();
		// Designate that the ball starts in the plunger area
		plunger = true;
	}
	
	// Update is called once per frame
	void Update () {
		// Check if the ball is in the plunger area or dead
			if (Input.GetKeyDown (KeyCode.Space) && transform.position.x < 0.1f &&
			    transform.position.y < 9.1f && plunger) {
			// Apply upward force on the ball
			rb.AddForce (transform.up * thrust);
			plunger = false;
		} else if (transform.position.y < 3.0f) {
			// If total lives is = 0, end the game
			if (Lives.getLives() > 0) {	
				// If the ball is dead, deduct from total lives
				Lives.loseLife();
				// Reset the velocities
				rb.velocity = new Vector3(0, 0, 0);
				rb.angularVelocity = new Vector3(0, 0, 0);
				// Make new ball at plunger area
				Instantiate(rb, startPos, Quaternion.identity);
				// Turn on the plunger
				plunger = true;
			}
			// Destroy current ball
			Destroy(gameObject);
		}
	}
}
