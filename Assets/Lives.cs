using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {
	public TextMesh lifeText;
	private static int lives = 3;
	public static bool gameOver = false; // If the lives < 0 (wait for coin)
	// Sound Effect Variables
	public static AudioClip end;
	public AudioClip endSet;
	public static AudioClip restart;
	public AudioClip restartSet;
	private static AudioSource source;

	void Awake () {
		source = GetComponent<AudioSource>();
		end = endSet;
		restart = restartSet;
	}

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
			source.PlayOneShot(end, 1.0f);
		}
	}

	public static int getLives() {
		return lives;
	}

    public static void reset() {
		print ("3 lives gained!");
		// Restart game
		gameOver = false;
		// Play sound effect
		source.PlayOneShot(restart, 1.0f);
		// Reset Lives
        lives = 3;
		// Reset the score
		Score.resetScore ();
		// Reset Ball
		GameObject ball = GameObject.FindGameObjectWithTag ("Ball");
		PinballScript.resetBall (ball);

    }
}
