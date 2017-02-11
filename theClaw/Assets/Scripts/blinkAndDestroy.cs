using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkAndDestroy : MonoBehaviour {
	/*** This script sets a timer on rocks to be destroyed after 10 seconds and to 
		 flicker for the last 2 seconds of that 10 seconds ***/
	private float rockLife = 10f;  //rock has 10 seconds before blinking out
	private float blinkPeriod = .3f;  //period at which rock blinks before destroy
									  //.3 seconds
	private float blinkTime = 2f;  //how long rock blinks before destroy
	private float numFlashes;		//used to calculate flashes so the rock blinks on and off using % 2
	private float currRockTime;		//timer
	private dropRock dropScript;    //other script on the rock object.  Used to see if rock has been dropped
									//only start timer after rock has been dropped
	private SpriteRenderer spriteRenderer;	//used for opacity of current rock object

	// Use this for initialization
	void Start () {
		currRockTime = rockLife;  //set timer
		numFlashes = Mathf.Ceil(blinkTime/blinkPeriod);  //total number of flashes for last 2 seconds
		dropScript = GetComponent<dropRock>();  //get dropScript for hasDropped
		spriteRenderer = GetComponent<SpriteRenderer> ();  //initialize renderer

	}
	
	// Update is called once per frame
	void Update () {
		//	print (dropScript.hasDropped);
		if (dropScript.hasDropped) {  //has rock dropped?
			if (currRockTime <= 0) {  //timer expired?
				Destroy (this.gameObject);  //destroy rock
			} else if (currRockTime <= blinkTime) {  //2 seconds to go?
				float opacity = (numFlashes - Mathf.Ceil (currRockTime / blinkPeriod)) % 2;  //set opacity to blink value
																							 //on or off depending on time
				spriteRenderer.color = new Color (1f, 1f, 1f, opacity);						 //blink
				currRockTime -= Time.deltaTime;  	//decrement timer
			} else {
				currRockTime -= Time.deltaTime;   //decrement timer
			}
		}
	}
}
