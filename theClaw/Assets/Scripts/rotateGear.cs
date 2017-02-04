using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateGear : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))  //when moving left rotate gear sprite left
		{
			transform.Rotate (new Vector3 (0, 0, 90) * Time.deltaTime);		
		}
		if (Input.GetKey(KeyCode.RightArrow))  //when moving right rotate gear sprite right
		{
			transform.Rotate (new Vector3 (0, 0, -90) * Time.deltaTime);		
		}
	}
}
