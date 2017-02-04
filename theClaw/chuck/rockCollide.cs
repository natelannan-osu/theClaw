using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockCollide : MonoBehaviour {
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D other) {  //2d collider that has been touched
		if (other.gameObject.CompareTag ("rock") || other.gameObject.CompareTag ("desert")) {
			if (!audioSource.isPlaying) {
				audioSource.Play ();
			}
		}
	}
}
