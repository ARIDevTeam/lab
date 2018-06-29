using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager1 : MonoBehaviour {

	//reference to the text object in scene that shows the random number
	public Text presentationNumber;

	//interaval between presentations of random number
	public float intervalNumber = 3.0f;

	//bool value that determines in the random number should be visible
	private bool visible = true;

	// Use this for initialization
	void Start () {
		getRandomNumer ();
	}

	//happens every frame
	void FixedUpdate() {
		intervalNumber -= Time.deltaTime;
		if (intervalNumber <= 0) {
			switch (visible) {
			//if the object was active make it invisible, reset the delay interval
			case true:
				getRandomNumer ();
				presentationNumber.gameObject.SetActive (false);
				intervalNumber = 3.0f;
				visible = false;
				break;
			//if the text object was inative, make it visible, get a new random number, reset the delay interval
			case false:
				getRandomNumer ();
				presentationNumber.gameObject.SetActive (true);
				intervalNumber = 3.0f;
				visible = true;
				break;
			}

			intervalNumber = 3.0f;
		}

	}


	//randomly generate a number between 0 and 9 and assign it to the text object's text value
	void getRandomNumer(){
		string num;
		int temp = UnityEngine.Random.Range (0, 9);
		num = temp.ToString ();
		presentationNumber.text = num;

	}

	//allows for the 3 second delay in the random presentation
	IEnumerator waitBeforeNewNum(float waitTime) {

		yield return new WaitForSeconds(waitTime);
		getRandomNumer ();
	}

	//Gives a 3 second delay before presenting a random number
	void randNumWithDelay(){
		StartCoroutine (waitBeforeNewNum (3.0f));
	}

	//provides the delay associated with the scene change
	IEnumerator waitaTick(float waitTime) {

		yield return new WaitForSeconds(waitTime);
		ChangeScene ();
	}

	//provides a brief delay before changing scenes
	public void hesitate(){
		StartCoroutine (waitaTick (0.75f));
	}

	//changes the scene
	void ChangeScene(){
		SceneManager.LoadScene ("Tutorial2");
	}
}
