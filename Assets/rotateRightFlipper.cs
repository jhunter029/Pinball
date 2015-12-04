using UnityEngine;
using System.Collections;

public class rotateRightFlipper : MonoBehaviour {
	private Vector3 startPos; // Starting position
	private Quaternion startRot; // Starting rotation
	private Vector3 currEuler; // Current Euler angle
	private Vector3 startEuler; // Starting Euler angle
	private Vector3 destEuler = Vector3.zero; // Destination Euler angle
	public float rotAmount = 270.0f; // Amount to rotate by
	public float speed = 30.0f;
	private int reset = 20; // Frames to wait before resetting flipper

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		startRot = transform.rotation;
		currEuler = transform.eulerAngles;
		startEuler = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X)) {
			// Rotate by the desired amount in the z-axis
			destEuler.z = rotAmount;
			// Adjust the euler angles for the object
			currEuler = Vector3.Lerp(currEuler, destEuler, Time.deltaTime * speed);
			transform.eulerAngles = currEuler;
			reset = 20;
		} else if (reset <= 0) {
			// Reset angle
			currEuler = Vector3.Lerp(currEuler, startEuler, Time.deltaTime * speed);
			transform.eulerAngles = currEuler;
			// Reset frame wait
			reset = 20;
		} else {
			// Decrement frame wait
			reset--;
		}
	}
}