﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SR_CSM : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//provides the delay associated with the scene change
	IEnumerator waitaTick(float waitTime) {

		yield return new WaitForSeconds(waitTime);
		ChangeToSTIntroScene ();
	}

	//provides a brief delay before changing scenes
	public void Hesitate(){
		StartCoroutine (waitaTick (0.75f));
	}

	//loads the background scene
	void ChangeToSTIntroScene(){
		SceneManager.LoadScene("ST_Intro");
	}
}
