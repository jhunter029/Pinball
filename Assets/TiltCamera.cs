using UnityEngine;
using System.Collections;

public class TiltCamera : MonoBehaviour {
	private Quaternion startRot;
	// Use this for initialization
	void Start () {
		startRot = transform.rotation;

	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(0, 0, 90 * PinballSerial.tilt);
		Physics.gravity = new Vector3(0, -9.81f * (1 - Mathf.Abs(PinballSerial.tilt)), -9.81f * PinballSerial.tilt);
		//print (Physics.gravity);
	}
}
