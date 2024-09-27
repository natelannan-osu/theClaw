﻿#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ControllerMaps : MonoBehaviour {

	[InitializeOnLoad]
	public class Startup
	{
		public static string opSys = "Unknown";
		public static int triggerDown;
		public static int triggerUp;
		public static string inputAxis;
		static Startup() {
			if (Application.platform == RuntimePlatform.WindowsEditor 
				|| Application.platform == RuntimePlatform.WindowsPlayer) {
				opSys = "Win";
				triggerDown = 1;
				triggerUp = 0;
				inputAxis = "rock_win";

			}
			else if (Application.platform == RuntimePlatform.OSXEditor
				|| Application.platform == RuntimePlatform.OSXPlayer){
				opSys = "OSX";
				triggerDown = 1;
				triggerUp = -1;
				inputAxis = "rock_mac";
			}
//			Debug.Log(opSys);
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
#endif
