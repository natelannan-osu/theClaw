using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdownTimer : MonoBehaviour {
	public Text displayTime;
	[HideInInspector]
	public bool done;
	private float timer;
	private int min;
	private int endScene = 2;
	private float sec;
	private float blinkPeriod = .3f;  //period at which rock blinks before destroy
	//.3 seconds
	private float numFlashes;		//used to calculate flashes so the rock blinks on and off using % 2
	// Use this for initialization
	void Start () {
		numFlashes = Mathf.Ceil(10.0f/blinkPeriod);
		timer = 120;
		min = 2;
		sec = 0.0f;
		updateTime ();
		done = false;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer >= 0.0f) {
			min = (int)Mathf.Floor (timer / 60);
			sec = timer - (min * 60);
			if (min == 0 && sec <= 10) {
				float opacity = (numFlashes - Mathf.Ceil (timer / blinkPeriod)) % 2;
				displayTime.color = new Color (1f, 0f, 0f, opacity);
			}
			updateTime ();
		} else {
			SceneManager.LoadScene (endScene);
		}
	}

	void updateTime (){
		if (sec < 10) {
			displayTime.text = "Time: " + min.ToString () + ":0" + sec.ToString ("F2");
		} else {
			displayTime.text = "Time: " + min.ToString () + ":" + sec.ToString ("F2");
		}
	}
}
