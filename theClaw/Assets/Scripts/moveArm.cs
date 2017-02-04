using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveArm : MonoBehaviour {
	private AudioSource audioSource;  //chain sound moving arm


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();  //get audio source sound
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {  //only play sound if moving
			audioSource.Stop ();
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (!audioSource.isPlaying) {  //play sound if not already playing
				audioSource.Play ();
			}
			if (transform.localPosition.x >= -3.8f) {  //move left until edge
				transform.Translate (-.1f, 0f, 0f);  //move left
			}
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			if (!audioSource.isPlaying) {  //play sound if not already playing
				audioSource.Play ();
			}
			if (transform.localPosition.x <= 9.5f)  //move right until edge
			{
				transform.Translate(.1f, 0f, 0f); //move right
			}

		}
	}
}
