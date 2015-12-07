using UnityEngine;
using System.Collections;

public class PinballScript : MonoBehaviour {
    // Sound Effect Variables
	public AudioClip plungerSfx;
	private AudioSource source;
    
    // Physics Variables
	private Rigidbody rb; // game object's rigidbody reference
	private int maxThrust = 900/4; // max thrust ball can receive without going haywire
	private  Vector3 startPos; // the starting position
	private int max = 1; // max value of that plunger set
	private bool gameOver = false; // If the ball is out of play (wait for coin)
	// Use this for initialization
	void Start () {
        // Get the starting transform in the plunger area
		startPos = transform.position;
		// Set the rigidbody reference variable
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			// Check if the ball is in the plunger area or dead
			if (transform.position.x < 0.1f && transform.position.y < 9.1f
			    && transform.position.y > 3.0f) {
				// Wait for the max value to be met - allows people to pull back slowly
				if (max <= PinballSerial.plunger) {
					//StartCoroutine(plungeWait());
					max = PinballSerial.plunger;
				} else {
					// Apply upward force on the ball
					rb.AddForce (transform.up * (maxThrust * max + 500));
					max = 1;
				}

			} else if (transform.position.y < 3.0f) {
				// If the ball is dead, deduct from total lives
				Lives.loseLife ();
				// If total lives is >= 0, continue game; else, end
				if (Lives.getLives () >= 0) {	
					// Reset the velocities
					rb.velocity = new Vector3 (0, 0, 0);
					rb.angularVelocity = new Vector3 (0, 0, 0);
					// Make new ball at plunger area
					Instantiate (rb, startPos, Quaternion.identity);
				}
				// Destroy current ball
				Destroy (gameObject);
			}  
		} else {
			if (PinballSerial.coin) {
				gameOver = false;
				Lives.reset();
			}
		}
	}
	IEnumerator plungeWait() {

		yield return new WaitForSeconds(0.05f);
	}
	

}

