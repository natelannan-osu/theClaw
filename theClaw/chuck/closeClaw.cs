using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeClaw : MonoBehaviour {
	//private GameObject clawClosed;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
		{
			gameObject.SetActive (false);
			//rigidBody.AddForce(new Vector3(1f, 0.759f, 0f) * shotForce);  //originally a fixed vector need to move force as cannon pivots
			//rigidBody.AddForce(cannonTransform.right * shotForce);
			//audioSource.Play();
			//hasDropped = true;
		}
		else{
		//if (Input.GetKeyUp(KeyCode.Space)) {
			gameObject.SetActive (true);
		}
	}
}
