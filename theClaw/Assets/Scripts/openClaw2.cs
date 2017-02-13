using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class openClaw2 : MonoBehaviour {
	/*** This Script opens claw by swapping two sprites on pressing space key as well as adding sound effects for the claw ***/
	public Sprite openClaw;  //opened claw sprite
	public Sprite closedClaw;  //closed claw sprite

	private SpriteRenderer spriteRenderer;  //for switching claw states
	private AudioSource openClawSound;  //squeak of opening claw
	private AudioSource closeClawSound;  //slam of closing claw
	private bool wasOpen = false;  //check last claw state

	[InitializeOnLoad]
	public class Startup
	{
		public static string opSys = "Unknown";
		public static int triggerDown;
		public static int triggerUp;
		public static string inputAxis;
		static Startup() {
			if (Application.platform == RuntimePlatform.WindowsEditor 
				|| Application.platform == RuntimePlatform.WindowsPlayer
				|| Application.platform == RuntimePlatform.WindowsWebPlayer) {
				opSys = "Win";
				triggerDown = 1;
				triggerUp = 0;
				inputAxis = "rock_win";
			}
			else if (Application.platform == RuntimePlatform.OSXEditor
				|| Application.platform == RuntimePlatform.OSXPlayer
				|| Application.platform == RuntimePlatform.OSXWebPlayer
				|| Application.platform == RuntimePlatform.OSXDashboardPlayer){
				opSys = "OSX";
				triggerDown = 1;
				triggerUp = -1;
				inputAxis = "rock_mac";
			}
		}
	}


	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();  //initialize renderer
		if (spriteRenderer.sprite == null)  //default sprite is closed claw
			spriteRenderer.sprite = closedClaw;
		var aSources = GetComponents<AudioSource> ();  //get audio sources
		openClawSound = aSources [0];  //squeak
		closeClawSound = aSources [1];  //slam
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space) || Input.GetAxis(Startup.inputAxis) == Startup.triggerDown)  //open claw when space bar pressed
		{
			spriteRenderer.sprite = openClaw;  //open claw
			if (!openClawSound.isPlaying && !wasOpen) {  //if not playing squeak and transitioning from closed claw to open claw
				openClawSound.Play ();  //play squeak
			}
			wasOpen = true;  //change state to reflect open claw
		}
		else{
			spriteRenderer.sprite = closedClaw;  //any other time close claw
			if (wasOpen) {  // transition from open claw to closed claw
				closeClawSound.Play ();  //play slam
				wasOpen = false;  //change state to reflect closed claw
			}

		}
	}
}
