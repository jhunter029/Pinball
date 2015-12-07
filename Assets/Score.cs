using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public TextMesh scoreText;
	private static int score = 0;
	
	public void Update ()
	{
		scoreText.text = "SCORE: " + score + "pts";
	}
	
	public static void addScore (int increment)
	{
		score += increment;
	}

	public static void resetScore() {
		score = 0;
	}
	
	
}