using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropRock : MonoBehaviour {

	public GameObject claw;  //needed to move rock with claw until it is dropped
	public GameObject rockObject;  //needed for spawning new rocks
	public AudioClip impact;  //rock collision sound
	public Sprite rockSprite1;  //rock sprites
	public Sprite rockSprite2;
	public Sprite rockSprite3;
	public float waitForRock = 0.5f;
	private Rigidbody2D rigidBody;  //rock rigid body
	private Vector3 offset;  //offset of rock original position to claw original position 
	private bool hasDropped = false;  //state of current rock
	private bool reload = false;  //need to reload claw
	private bool hitGround = false;  //first impact, for playing sounds
	private bool rendered = false;
	private Vector2 rockVelocity;  //rock velocity to calculate how loud sound plays
	private float audioVolume;  //volume for rock collision sound
	private float rngRock;  //randomly generate rock sprites
	private float timeUntilDrop;
	private float rockLife = 10f;  //rock has 5 seconds before blinking out
	private float currRockTime;
	private float blinkPeriod = .3f;  //period at which rock blinks before destroy
	private float blinkTime = 2f;  //how long rock blinks before destroy
	private float numFlashes;
	private AudioSource audioSource;  //get rock collision sound
	private SpriteRenderer spriteRenderer;  //sprite renderer to generate rock sprites



	// Use this for initialization
	void Start () {
		timeUntilDrop = waitForRock;
		currRockTime = rockLife;
		numFlashes = Mathf.Ceil(blinkTime/blinkPeriod);
		spriteRenderer = GetComponent<SpriteRenderer> ();  //initialize renderer
		rigidBody = GetComponent<Rigidbody2D> ();  //rock rigid body 
		offset = transform.position - claw.transform.position;  //offset of original positions for following claw before drop
		audioSource = GetComponent<AudioSource> ();  //rock collision sound
		rngRock = Random.Range (0.0f, 3.0f);
		if (spriteRenderer.sprite == null) {
			spriteRenderer.sprite = rockSprite1;
		}
	}

	void FixedUpdate(){  //physics being used for rocks  fixed update so rocks don't get jostled before drop
		if (!hasDropped) {
			rigidBody.MovePosition (claw.transform.position + offset);  //move rock with claw
		}
	}
	// Update is called once per frame
	void Update () {
		if (!hasDropped) {
			if (!rendered) {			
				if (rngRock <= 2.0f) {  //generate a rock sprite randomly
					if (rngRock <= 1.0f) {
						spriteRenderer.sprite = rockSprite1;
					} else {
						spriteRenderer.sprite = rockSprite2;
					}
				} else {
					spriteRenderer.sprite = rockSprite3;
				}
				rendered = true;
			}
			if (Input.GetKeyDown (KeyCode.Space) && !reload) {  //open claw and drop rock
				rigidBody.gravityScale = 1f;  //give it gravity
				hasDropped = true;  //dropped, need to reload
				reload = true; 
			} 
		} else if (currRockTime <= 0) {
			Destroy (this.gameObject);
		} else if (currRockTime <= blinkTime) {
			float opacity = (numFlashes - Mathf.Ceil (currRockTime / blinkPeriod)) % 2;
			spriteRenderer.color = new Color (1f, 1f, 1f, opacity);
			currRockTime -= Time.deltaTime;
		} else {
			currRockTime -= Time.deltaTime;
		}
		if (timeUntilDrop <= 0) {
			if (reload && Input.GetKeyUp (KeyCode.Space)) { //reload after claw closedt
				Instantiate (rockObject, claw.transform.position + offset, Quaternion.identity);  //put new rock behind claw				
				reload = false;  //loaded
				timeUntilDrop = waitForRock;
			}
		} else {
			timeUntilDrop -= Time.deltaTime;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {  //rock hit something
		if (other.gameObject.tag == "rock") {  //another rock
			rockVelocity = rigidBody.velocity;  //make a sound proportional to magnitude of velocity vector
			if (rockVelocity.magnitude > 4 ) {
				audioVolume = 1;
			} else {
				audioVolume = rockVelocity.magnitude / 4;
			}
			if (!audioSource.isPlaying && transform.position.y < -1) {  //make sure rock has cleared the claw before playing sounds
				audioSource.PlayOneShot (impact, audioVolume);  //play
				hitGround = true;  //initial impact has happened
			}
		}
		if (other.gameObject.tag == "desert") { //the ground
			if (hitGround == false) {  //only play a sound if hitting ground on initial impact
				audioSource.PlayOneShot (impact, .6f);
				hitGround = true;  //initial impact has happened
			}
		}
	}
	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}
}
