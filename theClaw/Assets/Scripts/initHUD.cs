using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initHUD : MonoBehaviour {
	public Text initScore;
	public Text initTime;
	// Use this for initialization
	void Start () {
		initScore.text = "Score: " + ApplicationModel.hitCount.ToString();
		initTime.text = "Time: 2:00.00";
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
