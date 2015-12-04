using UnityEngine;
using System.Collections;

public class rotateLeftFlipper : MonoBehaviour {
	private Vector3 startPos; // Starting position
	private Quaternion startRot; // Starting rotation
	private Vector3 currEuler; // Current Euler angle
	private Vector3 startEuler; // Starting Euler angle
	private Vector3 destEuler = Vector3.zero; // Destination Euler angle
	public float rotAmount = 60.0f; // Amount to rotate by - dependent on force of flipper
	private int reset = 15; // Frames to wait before resetting flipper
	private Transform pivot; // left pivot point
	private bool down = true; // flag to see if the flipper is down

	// Use this for initialization
	void Start () {
		// Default all values to the starting positions
		startPos = transform.position;
		startRot = transform.rotation;
		startEuler = transform.eulerAngles;
		currEuler = transform.eulerAngles;

		// Set reference to the pivot point
		pivot = transform.Find("Left Pivot Point");
	}
	
	// Update is called once per frame
	void Update () {
		// For testing purposes, I'm using the Z key instead of a dynamic rotation amount to trigger the flipper
		if (Input.GetKeyDown (KeyCode.Z) && down) {
			// Rotate the flipper by the desired amount
			transform.Rotate(Vector3.forward * rotAmount);
			// Do maths to reposition the flipper
			// It rotates around the center, not the left end
			float pos = Mathf.Abs(transform.position.x - pivot.position.x);
			float diffY = Mathf.Abs(transform.position.y - pivot.position.y);
			transform.position = new Vector3(transform.position.x - pos - Mathf.Abs(pos * Mathf.Cos (rotAmount * 3.1415926f / 180.0f)),
			                                 transform.position.y + Mathf.Abs(pos * Mathf.Sin (rotAmount * 3.1415926f / 180.0f)),
			                                 transform.position.z);
			transform.Translate(Vector3.left * Mathf.Abs(pos - Mathf.Abs(pos * Mathf.Cos (rotAmount * 3.1415926f / 180.0f))));
			transform.Translate(Vector3.up * Mathf.Abs(diffY -Mathf.Abs(pos * Mathf.Sin (rotAmount * 3.1415926f / 180.0f))));
			// Mark that the flipper is up
			down = false;
			// Start the reset counter
			reset = 15;
		} else if (reset == 0) {
			//Reset angle and position
			transform.position = startPos;
			transform.rotation = startRot;
			transform.eulerAngles = startEuler;
			// Reset reset counter
			reset = 15;
			// Mark that the flipper has been reset
			down = true;
		} else {
			// Decrement frame wait
			reset--;
		}
	}

	// Detect Collisions with the Ball
	void OnCollisionStay (Collision col)
	{	// If the object is a ball, bounce it with a force dependent on the rotation amount (the variable changed by the controller)
		if(col.gameObject.tag == "Ball" && !down)
		{
			col.rigidbody.AddForce(Vector3.up * rotAmount * 2, ForceMode.Acceleration);
		}
	}
}