using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wagTail : MonoBehaviour {
	/*** This Script is to cause Cat Person's tail to wag upon getting hit in the head with a rock ***/
	private float rightTailLimit = .05f;  //right rotation limit for tail
	private float leftTailLimit = .05f;  //left rotation limit for tail
	private float defaultTail;  //starting position of tail
	private bool left = true;  //start wagging left first
	private bool inbounds = true;  //test if last wag was within limits
	makeFrown myParent;  //check parent object's frown state
	// Use this for initialization
	void Start () {
		defaultTail = transform.rotation.z;  //current rotation position at start
		myParent = transform.parent.GetComponent<makeFrown> ();  //get Cat Person's frown state
	}
	
	// Update is called once per frame
	void Update () {
		if (myParent.frowning){
			if (transform.rotation.z > (defaultTail - leftTailLimit) && 
				transform.rotation.z < (defaultTail + rightTailLimit)) { //test limits
				if (left) { //start wag left
					transform.Rotate (new Vector3 (0, 0, 90) * Time.deltaTime);
				} else { //start wag right
					transform.Rotate (new Vector3 (0, 0, -90) * Time.deltaTime);
				}
				inbounds = true;  //still inbounds
			} else {
				if (inbounds) {  //if still out of bounds, don't reverse direction
					left = !left;  //hit edge reverse direction
				}
				if (left) { //wag left
					transform.Rotate (new Vector3 (0, 0, 90) * Time.deltaTime);
				} else { //wag right
					transform.Rotate (new Vector3 (0, 0, -90) * Time.deltaTime);
				}
				inbounds = false;  //out of bounds flag
			}
		}
	}
}
