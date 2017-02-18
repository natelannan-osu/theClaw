using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeFrown : MonoBehaviour {
	/*** This Script is to cause cartoon people to frown and yelp when hit by rock ***/
	public Sprite smile;  //default facial expression
	public Sprite frown;  //frown when hit by rock  
	[HideInInspector]
	public bool frowning;  //used by tail child in cat person
	//[HideInInspector]
	//public static int hitCount;
	public Text Score;
	public GameObject desert;

	private float holdFrownTime = 1f;  //how long to hold frown
	private float timeUntilSmile;  //wait until smile
	private SpriteRenderer spriteRenderer;  //for switching mouth states
	private AudioSource yelp;  //person sound when hit
	private float rockYpos;
	private countdownTimer gameTime;
	//private GameObject rockObject;
	// Use this for initialization
	void Start () {
		timeUntilSmile = holdFrownTime;  //set to holdFrownTime
		spriteRenderer = GetComponent<SpriteRenderer> ();  //initialize renderer
		if (spriteRenderer.sprite == null)  //default sprite is smile
			spriteRenderer.sprite = smile;
		yelp = GetComponent<AudioSource> ();  //specify yelp sound
		//hitCount = 0;
		UpdateScore ();
		gameTime = desert.GetComponent<countdownTimer>();
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
		if (other.gameObject.tag == "rock") {  //rock hit person
			rockYpos = other.gameObject.transform.position.y;
			if(!other.gameObject.GetComponent<dropRock> ().initialContact){
				if (rockYpos > -3.2f  && !gameTime.done) {
					ApplicationModel.hitCount++;
					UpdateScore ();
					//Physics2D.IgnoreCollision (other.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> ()); 
					if (!frowning) {
						spriteRenderer.sprite = frown;  //cause frown
						yelp.Play ();  //play yelp sound
						frowning = true;  //set flag
					}
				}
			}
		}
	}

	void UpdateScore (){
		Score.text = "Score: " + ApplicationModel.hitCount.ToString ();
	}
}
