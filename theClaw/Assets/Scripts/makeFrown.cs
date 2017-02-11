using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeFrown : MonoBehaviour {
	/*** This Script is to cause cartoon people to frown and yelp when hit by rock ***/
	public Sprite smile;  //default facial expression
	public Sprite frown;  //frown when hit by rock  
	public bool frowning;  //used by tail child in cat person

	private float holdFrownTime = 1f;  //how long to hold frown
	private float timeUntilSmile;  //wait until smile
	private SpriteRenderer spriteRenderer;  //for switching mouth states
	private AudioSource yelp;  //person sound when hit
	private float rockYpos;
	// Use this for initialization
	void Start () {
		timeUntilSmile = holdFrownTime;  //set to holdFrownTime
		spriteRenderer = GetComponent<SpriteRenderer> ();  //initialize renderer
		if (spriteRenderer.sprite == null)  //default sprite is smile
			spriteRenderer.sprite = smile;
		yelp = GetComponent<AudioSource> ();  //specify yelp sound
	}
	
	// Update is called once per frame
	void Update () {
		if (frowning && (timeUntilSmile <= 0)) {  //wait for timeout to start smiling again
			spriteRenderer.sprite = smile;  //smile
			frowning = false;  //reset flag
			timeUntilSmile = holdFrownTime;  //reset timer
		} else if (frowning){  //hold frown
			timeUntilSmile -= Time.deltaTime;  //decrement timer
		}
		
	}
	void OnCollisionEnter2D(Collision2D other) {  //collision
		if (other.gameObject.tag == "rock" && !frowning) {  //rock hit person
			rockYpos = other.gameObject.transform.position.y;
			if ( rockYpos > -3.2f ) {
				spriteRenderer.sprite = frown;  //cause frown
				yelp.Play ();  //play yelp sound
				frowning = true;  //set flag
			}
		}
	}
}
