using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {
	public GUIText lifeText;
	private static int lives = 3;
	
	public void Update ()
	{
		lifeText.text = "Lives Remaining: " + lives;
	}
	
	public static void loseLife ()
	{
		lives--;
	}
}
