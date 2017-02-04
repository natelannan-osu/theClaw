using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeFrown : MonoBehaviour {
	public Sprite smile;  //default facial expression
	public Sprite frown;  //frown when hit by rock
	public float holdFrownTime = 1f;
	public bool frowning;  //used by tail child in cat person

	private float timeUntilSmile;
	private SpriteRenderer spriteRenderer;  //for switching mouth states
	private AudioSource yelp;  //person sound when hit
	// Use this for initialization
	void Start () {
		timeUntilSmile = holdFrownTime;
		spriteRenderer = GetComponent<SpriteRenderer> ();  //initialize renderer
		if (spriteRenderer.sprite == null)  //default sprite is smile
			spriteRenderer.sprite = smile;
		yelp = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (frowning && timeUntilSmile <= 0) {
			spriteRenderer.sprite = smile;
			frowning = false;
			timeUntilSmile = holdFrownTime;
		} else if (frowning){
			timeUntilSmile -= Time.deltaTime;
		}
		
	}
	void OnCollisionEnter2D(Collision2D other) {  //collision
		if (other.gameObject.tag == "rock" && !frowning) {  //rock hit person
			spriteRenderer.sprite = frown;  //open claw
			yelp.Play ();
			frowning = true;
		}
	}
}
