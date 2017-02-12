using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdownTimer : MonoBehaviour {
	public Text displayTime;
	private float timer;
	private int min;
	private float sec;
	// Use this for initialization
	void Start () {
		timer = 120;
		min = 2;
		sec = 0.0f;
		updateTime ();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer >= 0.0f) {
			min = (int)Mathf.Floor (timer / 60);
			sec = timer - (min * 60);
			updateTime ();
		} else {
			min = 0;
			sec = 0.0f;
			updateTime ();
			Time.timeScale = 0;
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
