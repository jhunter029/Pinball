using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {
	public TextMesh lifeText;
	private static int lives = 3;
	public static bool gameOver = false; // If the lives < 0 (wait for coin)
	
	public void Update () {
		if (!gameOver) {
			lifeText.text = "Lives Remaining: " + lives;
		} else {
			lifeText.text = "Insert coin to continue";
			if (PinballSerial.coin) {
				reset();
			}
		}
	}
	
	public static void loseLife () {
		lives--;
		if (lives < 0) {
			gameOver = true;
		}
	}

	public static int getLives() {
		return lives;
	}

    public static void reset() {
		print ("3 lives gained!");
		// Restart game
		gameOver = false;
		// Reset Lives
        lives = 3;
		// Reset the score
		Score.resetScore ();
		// Reset Ball
		GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
		PinballScript.resetBall (ball);
    }
}
