using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveArm : MonoBehaviour {
	private AudioSource audioSource;
	//private bool audioIsPlaying = false;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
			audioSource.Stop ();
		}
		if (transform.localPosition.x >= -3.8f && Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-.1f, 0f, 0f);
			if (!audioSource.isPlaying) {
				audioSource.Play ();
			}
		}
		if (transform.localPosition.x <= 9.5f && Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(.1f, 0f, 0f);
			if (!audioSource.isPlaying) {
				audioSource.Play ();
			}
		}
	}
}
