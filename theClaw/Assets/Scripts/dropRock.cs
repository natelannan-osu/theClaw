using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class dropRock : MonoBehaviour {
	/*** This script controls the behavior of a rock object.  It causes it to follow the claw
		 object until the claw is opened with the space bar.  Renders 3 different rock images for
		 the rock object in a random mannner, and plays a sound if 2 rocks based on their velocities.
		 It also reloads the claw with another rock after the first has fallen and a timer has expired ***/
	public GameObject claw;  //needed to move rock with claw until it is dropped
	public GameObject rockObject;  //needed for spawning new rocks
	public AudioClip impact;  //rock collision sound
	public Sprite rockSprite1;  //rock sprites
	public Sprite rockSprite2;
	public Sprite rockSprite3;
	[HideInInspector]
	public bool hasDropped;  //state of current rock
	[HideInInspector]
	public bool initialContact;  //first hit happend.  use to ignore later hits for scoring

	private float waitForRock = .5f;  //time to wait before spawning new rock
	private Rigidbody2D rigidBody;  //rock rigid body
	private Vector3 offset;  //offset of rock original position to claw original position 

	private bool reload;  //need to reload claw
	private bool rendered;	//test to see if rock sprite needs to be loaded
	private bool closed;  //flag for claw state to be used in late update
	private Vector2 rockVelocity;  //rock velocity to calculate how loud sound plays
	private float audioVolume;  //volume for rock collision sound
	private float rngRock;  //randomly generate rock sprites
	private float timeUntilDrop;  //timer for how long to wait before spawning the next rock
	private AudioSource audioSource;  //get rock collision sound
	private SpriteRenderer spriteRenderer;  //sprite renderer to generate rock sprites
	//private openClaw2 clawScript;




	// Use this for initialization
	void Start () {
		hasDropped = false;  //start inside claw
		initialContact = false;  //hasn't hit anything
		reload = false;  //start loaded with a rock
		rendered = false;  //not rendered yet
		timeUntilDrop = waitForRock;  //set timer
		spriteRenderer = GetComponent<SpriteRenderer> ();  //initialize renderer
		rigidBody = GetComponent<Rigidbody2D> ();  //rock rigid body 
		offset = transform.position - claw.transform.position;  //offset of original positions for following claw before drop
		audioSource = GetComponent<AudioSource> ();  //rock collision sound
		rngRock = Random.Range (0.0f, 3.0f);  //for generating 1 of 3 rocks
		if (spriteRenderer.sprite == null) {  //initialize renderer
			spriteRenderer.sprite = rockSprite1;
		}
		closed = true;  //claw starts closed
		//clawScript = claw.GetComponent<openClaw2>();
	}

	void FixedUpdate(){  //physics being used for rocks  fixed update so rocks don't get jostled before drop
		if (!hasDropped) {
			rigidBody.MovePosition (claw.transform.position + offset);  //move rock with claw
		}
	}
	// Update is called once per frame
	void Update () {
		if (!hasDropped) {  //still in claw
			if (!rendered) {  //not rendered yet			
				if (rngRock <= 2.0f) {  //generate a rock sprite randomly
					if (rngRock <= 1.0f) {
						spriteRenderer.sprite = rockSprite1;
						spriteRenderer.color = new Color (1f, 1f, 1f, 0f);
					} else {
						spriteRenderer.sprite = rockSprite2;
						spriteRenderer.color = new Color (1f, 1f, 1f, 0f);
					}
				} else {
					spriteRenderer.sprite = rockSprite3;
					spriteRenderer.color = new Color (1f, 1f, 1f, 0f);
				}
				rendered = true;  //rendered
			}
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetAxis(openClaw2.Startup.inputAxis) == openClaw2.Startup.triggerDown) {  //open claw and drop rock
				spriteRenderer.color = new Color (1f, 1f, 1f, 1f);
				//transform.parent = null;
				rigidBody.gravityScale = 1f;  //give it gravity
				hasDropped = true;  //dropped, need to reload
				reload = true; //claw needs to be reloaded
				closed = false;  //claw is open used in late update
			} 
		} else {
			timeUntilDrop -= Time.deltaTime;  //rock released start timer for spawning new rock
		}
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetAxis(openClaw2.Startup.inputAxis) == openClaw2.Startup.triggerUp) { 
			closed=true;  //claw closed to be used with late update		
		}
	}

	void LateUpdate (){
		if (timeUntilDrop <= 0  && reload && closed) {  //spawn new rock when need to reload, timer expired, and 
																//claw closed.  make sure with late update reload is in 
																//correct state
			Instantiate (rockObject, claw.transform.position + offset, Quaternion.identity);  //put new rock behind claw				
			reload = false;  //loaded
		}
	}

	void OnCollisionEnter2D(Collision2D other) {  //rock hit something
		initialContact = true;
		if (other.gameObject.tag == "rock") {  //another rock
			rockVelocity = rigidBody.velocity;  //make a sound proportional to magnitude of velocity vector
			if (rockVelocity.magnitude > 4 ) {
				audioVolume = 1;
			} else {
				audioVolume = rockVelocity.magnitude / 4;
			}
			if (!audioSource.isPlaying && transform.position.y < -1) {  //make sure rock has cleared the claw before playing sounds
				audioSource.PlayOneShot (impact, audioVolume);  //play
			}
		}
	}
	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}
}
