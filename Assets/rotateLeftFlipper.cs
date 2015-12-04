using UnityEngine;
using System.Collections;

public class rotateLeftFlipper : MonoBehaviour {
	private Vector3 startPos; // Starting position
	private Quaternion startRot; // Starting rotation
	private Vector3 currEuler; // Current Euler angle
	private Vector3 startEuler; // Starting Euler angle
	private Vector3 destEuler = Vector3.zero; // Destination Euler angle
	public float rotAmount = -90.0f; // Amount to rotate by
	public float speed = 100.0f;
	//private int reset = 20; // Frames to wait before resetting flipper
	private Transform pivot; // left pivot point

	// Use this for initialization
	void Start () {
		// Default all values to the starting positions
		startPos = transform.position;
		startRot = transform.rotation;
		startEuler = transform.eulerAngles;
		currEuler = transform.eulerAngles;

		// Set reference to the pivot point
		//pivot = transform.Find("Left Pivot Point");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Z)) {

			// Rotate by the desired amount in the z-axis
			destEuler.z = rotAmount;
			// Adjust the euler angles for the object
			currEuler = Vector3.Lerp(currEuler, destEuler, Time.deltaTime * speed);
			transform.eulerAngles = currEuler;

			// Verify that the position hasn't changed
			transform.position = startPos;
			//transform.RotateAround(pivot.position, Vector3.right, rotAmount);
			//reset = 20;
		} else {
			// Reset angle
			// Reset angle
			currEuler = Vector3.Lerp(currEuler, startEuler, Time.deltaTime * speed);
			transform.eulerAngles = currEuler;
		} /**else if (reset == 20) {

		} else {
			// Decrement frame wait
			reset--;
		}
		**/
	}
}