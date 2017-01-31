using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openClaw2 : MonoBehaviour {
	public Sprite openClaw;
	public Sprite closedClaw;

	private SpriteRenderer spriteRenderer;
	private AudioSource openClawSound;
	private AudioSource closeClawSound;
	private bool wasOpen = false;


	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (spriteRenderer.sprite == null)
			spriteRenderer.sprite = closedClaw;
		var aSources = GetComponents<AudioSource> ();
		openClawSound = aSources [0];
		closeClawSound = aSources [1];
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
		{
			spriteRenderer.sprite = openClaw;
			if (!openClawSound.isPlaying && !wasOpen) {
				openClawSound.Play ();
			}
			wasOpen = true;
			//openClawSound.Play ();
			//rigidBody.AddForce(new Vector3(1f, 0.759f, 0f) * shotForce);  //originally a fixed vector need to move force as cannon pivots
			//rigidBody.AddForce(cannonTransform.right * shotForce);
			//audioSource.Play();
			//hasDropped = true;
		}
		else{
			spriteRenderer.sprite = closedClaw;
			if (wasOpen) {
				closeClawSound.Play ();
				wasOpen = false;
			}

		}
	}
}
