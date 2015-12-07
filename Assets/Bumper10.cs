using UnityEngine;
using System.Collections;

public class Bumper10 : MonoBehaviour {
	// Detect Collisions with the Ball
	void OnCollisionEnter (Collision col)
	{	// If the object is a ball, bounce it with a force dependent on the rotation amount (the variable changed by the controller)
		if(col.gameObject.tag == "Ball")
		{
			Score.addScore(10);
			col.rigidbody.AddForce( getRandomForce() * 300);
		}
	}

	private Vector3 getRandomForce() {
		Vector3[] dir = {Vector3.up, Vector3.down, Vector3.right, Vector3.left, Vector3.forward, Vector3.back};
		return dir [(int)Random.Range (0, 5)];
	}
}
