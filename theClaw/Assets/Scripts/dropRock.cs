using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropRock : MonoBehaviour {

	public GameObject claw;
	public GameObject rockObject;
	public AudioClip impact;
//	public Sprite rockSprite1;
//	public Sprite rockSprite2;
//	public Sprite rockSprite3;
	private Rigidbody2D rigidBody;
	private Vector3 offset;
	private bool hasDropped = false;
	private bool reload = false;
	private bool hitGround = false;
	private Vector2 rockVelocity;
	private float audioVolume;
	//private float rngRock;
	private AudioSource audioSource;
	//private SpriteRenderer spriteRenderer;

	//private Transform armTransform;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		offset = transform.position - claw.transform.position;
		audioSource = GetComponent<AudioSource> ();
		//rngRock = Random.Range (0.0f, 3.0f);
//		if (spriteRenderer.sprite == null) {
//			spriteRenderer.sprite = rockSprite1;
//		}
	}

	void FixedUpdate(){
		if (!hasDropped) {
			rigidBody.MovePosition (claw.transform.position + offset);
		}
	}
	// Update is called once per frame
	void Update () {
		if (!hasDropped) {
			//transform.position = claw.transform.position + offset; //camera follows player's position adding in initial starting position
//			if (rngRock <= 2.0f) {
//				if (rngRock <= 1.0f) {
//					spriteRenderer.sprite = rockSprite1;
//				} else {
//					spriteRenderer.sprite = rockSprite2;
//				}
//			} else {
//				spriteRenderer.sprite = rockSprite3;
//			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				rigidBody.gravityScale = 1f;
				//rigidBody.AddForce(new Vector3(1f, 0.759f, 0f) * shotForce);  //originally a fixed vector need to move force as cannon pivots
				//rigidBody.AddForce(cannonTransform.right * shotForce);

				//audioSource.Play();
				hasDropped = true;
				reload = true;
			}


		}
		if (reload  && Input.GetKeyUp(KeyCode.Space) ) { //reload
			Instantiate (rockObject, claw.transform.position + offset, Quaternion.identity);
					
			reload = false;
			//print("foo");
			//print (rigidBody.gravityScale);
			//hasDropped = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {  //2d collider that has been touched
		if (other.gameObject.tag == "rock") {
			rockVelocity = rigidBody.velocity;
			print (rockVelocity.magnitude);
			if (rockVelocity.magnitude > 4 ) {
				audioVolume = 1;
			} else {
				audioVolume = rockVelocity.magnitude / 4;
			}
			if (!audioSource.isPlaying && transform.position.y < -1) {
				audioSource.PlayOneShot (impact, audioVolume);
				hitGround = true;
			}
		}
		if (other.gameObject.tag == "desert") {
			if (hitGround == false) {
				audioSource.PlayOneShot (impact, .6f);
				hitGround = true;
			}
		}
	}
}
