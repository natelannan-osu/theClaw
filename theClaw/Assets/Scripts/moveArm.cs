using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveArm : MonoBehaviour {
	/*** This Script is to cause claw arm to move left and right on screen, stopping at screen edges ***/
	private AudioSource audioSource;  //chain sound moving arm
	private float speed = .025f;


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();  //get audio source sound
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX;
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow) || Input.GetAxis("Horizontal") == 0) {  //only play sound if moving
			audioSource.Stop ();
		}
		if (Input.GetKey (KeyCode.LeftArrow) || (Input.GetAxis("Horizontal") < 0)) {
			if (!audioSource.isPlaying) {  //play sound if not already playing
				audioSource.Play ();
			}
			if (transform.localPosition.x >= -3.8f) {  //move left until edge
				if (Input.GetKey (KeyCode.LeftArrow)) {
					transform.Translate (-speed, 0f, 0f);  //move left
				} else {
					deltaX = Input.GetAxis("Horizontal");
					transform.position = transform.position + new Vector3 (deltaX * speed, 0, 0);
				}
			}
		}
		if (Input.GetKey(KeyCode.RightArrow) || (Input.GetAxis("Horizontal") > 0)){
			if (!audioSource.isPlaying) {  //play sound if not already playing
				audioSource.Play ();
			}
			if (transform.localPosition.x <= 9.5f)  //move right until edge
			{
				if (Input.GetKey (KeyCode.LeftArrow)) {
					transform.Translate (speed, 0f, 0f); //move right
				} else {
					deltaX = Input.GetAxis("Horizontal");
					transform.position = transform.position + new Vector3 (deltaX * speed, 0, 0);
				}
			}

		}
	}
}
