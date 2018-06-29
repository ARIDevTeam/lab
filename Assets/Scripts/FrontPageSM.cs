using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FrontPageSM : MonoBehaviour {

	//declarations
	private String value;

	//notiifcations
	//public static event Action<String> sendUID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//loads the background scene
	public void changeToSRCInstructionsScene(){
		SceneManager.LoadScene("_Scenes/Tutorial1");
	}
}
