using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openClaw : MonoBehaviour {
	public GameObject claw;
	// Use this for initialization
	void Start () {
		claw.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			claw.SetActive (true);
			//rigidBody.AddForce(new Vector3(1f, 0.759f, 0f) * shotForce);  //originally a fixed vector need to move force as cannon pivots
			//rigidBody.AddForce(cannonTransform.right * shotForce);
			//audioSource.Play();
			//hasDropped = true;
		} else {
			claw.SetActive (false);
		}
	}
}
