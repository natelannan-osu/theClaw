using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wagTail : MonoBehaviour {

	private float rightTailLimit = .05f;
	private float leftTailLimit = .05f;
	private float defaultTail;
	private bool left = true;  //start wagging left first
	makeFrown myParent;
	// Use this for initialization
	void Start () {
		defaultTail = transform.rotation.z;
		myParent = transform.parent.GetComponent<makeFrown> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myParent.frowning){
			if (transform.rotation.z > (defaultTail - leftTailLimit) && transform.rotation.z < (defaultTail + rightTailLimit)) { //test limits
				if (left) { //wag left
					transform.Rotate (new Vector3 (0, 0, 90) * Time.deltaTime);
				} else { //wag right
					transform.Rotate (new Vector3 (0, 0, -90) * Time.deltaTime);
				}
			} else {
				Debug.Log("left: " + left);
				left = !left;
				if (left) { //wag left
					transform.Rotate (new Vector3 (0, 0, 90) * Time.deltaTime);
				} else { //wag right
					transform.Rotate (new Vector3 (0, 0, -90) * Time.deltaTime);
				}
				Debug.Log ("left after change: " + left);
			}
		}
	}
}
