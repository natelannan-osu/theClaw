using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour {

	public void LoadByIndex(int sceneIndex)
	{
		ApplicationModel.hitCount = 0;
		SceneManager.LoadScene (sceneIndex);
	}
}
