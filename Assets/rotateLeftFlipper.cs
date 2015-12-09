using UnityEngine;
using System.Collections;

public class rotateLeftFlipper : MonoBehaviour {
	private Vector3 startPos; // Starting position
	private Quaternion startRot; // Starting rotation
	private Vector3 currEuler; // Current Euler angle
	private Vector3 startEuler; // Starting Euler angle
	private Vector3 destEuler = Vector3.zero; // Destination Euler angle
	public float rotAmount = 60.0f; // Amount to rotate by - dependent on force of flipper
	private int reset = 10; // Frames to wait before resetting flipper
	private Transform pivot; // left pivot point
	private bool down = true; // flag to see if the flipper is down
    float amountRotatedBy;
    // Use this for initialization
    void Start () {
		// Default all values to the starting positions
		startPos = transform.position;
		startRot = transform.rotation;
		startEuler = transform.eulerAngles;
		currEuler = transform.eulerAngles;
        amountRotatedBy = 0;
		// Set reference to the pivot point
		pivot = transform.Find("Left Pivot Point");
	}

    // Update is called once per frame
   
    void Update () {
        // For testing purposes, I'm using the Z key instead of a dynamic rotation amount to trigger the flipper

        GameObject leftSphere = GameObject.Find("SphereLeft");
        float rotateAmount = 500 * Time.deltaTime;

        down = amountRotatedBy <= 0;

        if ((Input.GetKey("z") || PinballSerial.left)) {
            // Rotate the flipper by the desired amounts
            // Do maths to reposition the flipper
			// It rotates around the center, not the left end
		

            if (amountRotatedBy < 75) { 
                amountRotatedBy += rotateAmount;
                transform.RotateAround(leftSphere.transform.position, Vector3.forward, rotateAmount);
            }
            // Mark that the flipper is up
            down = false;
			// Start the reset counter
			reset = 10;
		}  else if (!(Input.GetKey("z")|| PinballSerial.left)) {

            if (amountRotatedBy > 0) {
                amountRotatedBy -= rotateAmount;
                transform.RotateAround(leftSphere.transform.position, Vector3.back, rotateAmount);
            }
            
            //Reset angle and position
            //transform.position = startPos;
            //transform.rotation = startRot;
            //transform.eulerAngles = startEuler;
            // Reset reset counter
            //reset = 10;
            // Mark that the flipper has been reset
            //down = true;
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