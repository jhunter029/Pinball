using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {
	public TextMesh lifeText;
	private static int lives = 3;
	
	public void Update () {
		if (lives >= 0) {
			lifeText.text = "Lives Remaining: " + lives;
		} else {
			lifeText.text = "Insert coin to continue";
		}

	}
	
	public static void loseLife () {
		lives--;
	}

	public static int getLives() {
		return lives;
	}

    public static void reset() {
        lives = 3;
    }
}
