﻿using UnityEngine;
using System.Collections;

public class Bumper20 : MonoBehaviour {
	// Sound Effect Variables
	public AudioClip impact;
	private AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource>();
	}

	// Detect Collisions with the Ball
	void OnCollisionEnter (Collision col)
	{	// If the object is a ball, bounce it with a force dependent on the rotation amount (the variable changed by the controller)
		if(col.gameObject.tag == "Ball")
		{	// Increment score
			Score.addScore(10);
			// Add force to the ball in a random direction
			col.rigidbody.AddForce( getRandomForce() * 300);
			// Play sound effect
			source.PlayOneShot(impact, 0.8f);
		}
	}

	private Vector3 getRandomForce() {
		Vector3[] dir = {Vector3.up, Vector3.down, Vector3.right, Vector3.left, Vector3.forward, Vector3.back};
		return dir [(int)Random.Range (0, 5)];
	}
}
