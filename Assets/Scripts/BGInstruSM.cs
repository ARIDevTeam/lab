using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BGInstruSM : MonoBehaviour {

	//declarations
	private String uid;

	//notiifcations
	public static event Action<String> sendUID;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//provides the delay associated with the scene change
	IEnumerator waitaTick(float waitTime) {

		yield return new WaitForSeconds(waitTime);
		changeToBackgroundScene ();
	}

	//provides a brief delay before changing scenes
	public void hesitate(){
		StartCoroutine (waitaTick (0.75f));
	}

	//loads the background scene
	public void changeToBackgroundScene(){
		SceneManager.LoadScene("Background");
	}
}
