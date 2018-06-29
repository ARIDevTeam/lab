/*This script will be implemented as a singleton on the gameobject
GameController located in the Waiver Scene. This script will
hold and collect all values for the user; then push them when done */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour {

	//declarations
	public static GameController gc = null;

	public Button agree;
	public Button disagree;

	void Awake(){
		if(gc==null){
			gc = this;
			DontDestroyOnLoad(gameObject);
		}else{
			Destroy(this);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	//This method will change to the background scene
	public void goToLoginScene(){
		SceneManager.LoadScene("FrontPage");
	}

	//this method closes the application
	public void shutDownSingleton(){
		gc = null;
		Destroy(this.gameObject);
		//application.Quit();
	}
}
