using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreativityTutSM : MonoBehaviour {


	//provides the delay associated with the scene change
	IEnumerator waitaTick(float waitTime) {

		yield return new WaitForSeconds(waitTime);
		ChangeToSR_CInstructionsScene ();
	}

	//provides a brief delay before changing scenes
	public void Hesitate(){
		StartCoroutine (waitaTick (0.75f));
	}

	//changes the scene
	void ChangeToSR_CInstructionsScene(){
		SceneManager.LoadScene ("Creativity");
	}
}
