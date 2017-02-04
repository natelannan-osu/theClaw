using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openClaw2 : MonoBehaviour {
	public Sprite openClaw;  //opened claw sprite
	public Sprite closedClaw;  //closed claw sprite

	private SpriteRenderer spriteRenderer;  //for switching claw states
	private AudioSource openClawSound;  //squeak of opening claw
	private AudioSource closeClawSound;  //slam of closing claw
	private bool wasOpen = false;  //check last claw state


	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();  //initialize renderer
		if (spriteRenderer.sprite == null)  //default sprite is closed claw
			spriteRenderer.sprite = closedClaw;
		var aSources = GetComponents<AudioSource> ();  //get audio sources
		openClawSound = aSources [0];  //squeak
		closeClawSound = aSources [1];  //slam
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))  //open claw when space bar pressed
		{
			spriteRenderer.sprite = openClaw;  //open claw
			if (!openClawSound.isPlaying && !wasOpen) {  //if not playing squeak and transitioning from closed claw to open claw
				openClawSound.Play ();  //play squeak
			}
			wasOpen = true;  //change state to reflect open claw
		}
		else{
			spriteRenderer.sprite = closedClaw;  //any other time close claw
			if (wasOpen) {  // transition from open claw to closed claw
				closeClawSound.Play ();  //play slam
				wasOpen = false;  //change state to reflect closed claw
			}

		}
	}
}
