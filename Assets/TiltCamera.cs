using UnityEngine;
using System.Collections;

public class TiltCamera : MonoBehaviour {
	private Quaternion startRot;
    private float tilt = 0.0f;
	// Use this for initialization
	void Start () {
		startRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        tilt = -PinballSerial.tilt / 2.0f;
		transform.rotation = Quaternion.Euler(0, 0, 90 * tilt);
		Physics.gravity = new Vector3(0, -9.81f * (1 - Mathf.Abs(tilt)), -9.81f * tilt);
		//print (Physics.gravity);
	}
}
