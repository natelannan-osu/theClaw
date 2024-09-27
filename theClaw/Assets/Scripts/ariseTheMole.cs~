using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ariseTheMole : MonoBehaviour {

	public GameObject[] mole;

	private bool moleSelected = false;
	private int moleIndex;
	private float xPosition;
	private float yStart;
	private float riseSpeed = 1.0f;
	private float stayTime = 2.0f;
	private float countdown;
	// Use this for initialization
	void Start () {
		mole = GameObject.FindGameObjectsWithTag ("mole");
		countdown = stayTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (!moleSelected) {
			moleIndex = Random.Range (0, 3);  //select the mole
			switch (moleIndex) {
			case 0:  //catperson
				xPosition = Random.Range (-7.0f, 7.0f); 
				break;
			case 1:  //purplelock
				xPosition = Random.Range (-7.25f, 7.25f);
				break;
			case 2:  //bigHair
				xPosition = Random.Range (-6.9f, 6.9f);
				break;
			default:
				Debug.Log ("Mole selection failure.");
				break;
			}
			yStart = mole [moleIndex].transform.position.y;
			mole [moleIndex].transform.position = new Vector3 (xPosition, yStart, 0f);
			moleSelected = true;
		} else {
			if (mole [moleIndex].transform.position.y < -3.8f && (countdown == stayTime)) {  //move up
				mole [moleIndex].transform.position = mole [moleIndex].transform.position + new Vector3 (0f, .1f * riseSpeed, 0f);
			} else {
				countdown -= Time.deltaTime;
				if (countdown <= 0) {
					if (mole [moleIndex].transform.position.y > yStart) {
						mole [moleIndex].transform.position = mole [moleIndex].transform.position + new Vector3 (0f, -.1f * riseSpeed, 0f);
					} else {
						moleSelected = false;
						countdown = stayTime;
					}
				}
			}
		}
	}
}
