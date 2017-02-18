using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayBestScore : MonoBehaviour {
	public Text score;
	public Text highScore;
	public Text scoreAlert;
	private static int oldHighScore = 0;
	// Use this for initialization
	void Start () {
		scoreAlert.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if ( ApplicationModel.hitCount > oldHighScore ) {  //beat high score
			highScore.text = "High Score: " + ApplicationModel.hitCount.ToString();
			oldHighScore = ApplicationModel.hitCount;
			scoreAlert.text = "New High Score ! ! !";
		}
		else{  //high score unbeaten
			highScore.text = "High Score: " + oldHighScore.ToString();
		}
		score.text = "Final Score: " + ApplicationModel.hitCount.ToString();
	}
}
