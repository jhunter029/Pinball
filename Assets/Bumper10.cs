using UnityEngine;
using System.Collections;

public class Bumper10 : MonoBehaviour {
	// Detect Collisions with the Ball
	void OnCollisionEnter (Collision col)
	{	// If the object is a ball, bounce it with a force dependent on the rotation amount (the variable changed by the controller)
		if(col.gameObject.tag == "Ball")
		{
			Score.addScore(10);
		}
	}
}
