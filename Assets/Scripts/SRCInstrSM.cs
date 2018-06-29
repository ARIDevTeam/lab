using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SRCInstrSM : MonoBehaviour {

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

	//provides the delay associated with the scene change
	IEnumerator waitaTick(float waitTime) {

		yield return new WaitForSeconds(waitTime);
		ChangeToSRCScene ();
	}

	//provides a brief delay before changing scenes
	public void Hesitate(){
		StartCoroutine (waitaTick (0.75f));
	}

	//loads the background scene
	void ChangeToSRCScene(){
		SceneManager.LoadScene("SR_C");
	}
}
